using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class PianoKeysModule : MonoBehaviour
{
    #region Types
    public enum Type
    {
        Normal,
        Cruel,
        Festive
    }
    #endregion

    #region Constants
    private const int DefaultOctave = 3;
    #endregion

    #region Public Fields
    public KMBombModule KMBombModule;
    public KMBombInfo KMBombInfo;
    public KMSelectable KMSelectable;
    public MeshRenderer ComponentMesh;
    public PianoPlayer PianoPlayer;
    public PianoIndicator PianoIndicator;
    public Type ModuleType;
    #endregion

    #region Private Properties
    private IEnumerable<Note> DecisionNotes
    {
        get
        {
            if (_correctDecision != null)
            {
                return _correctDecision.GetNotes(KMBombInfo);
            }

            return null;
        }
    }
    #endregion

    #region Private Fields
    private Decision _correctDecision = null;
    private int _currentNoteIndex = 0;
    #endregion

    #region Unity Lifetime
    private void Start()
    {
        for (int childIndex = 0; childIndex < KMSelectable.Children.Length; ++childIndex)
        {
            KMSelectable childSelectable = KMSelectable.Children[childIndex];
            SetupSelectableNote(childSelectable, (Semitone)childIndex);
        }

        KMBombModule.GenerateLogFriendlyName();

        MusicSymbol[] pickedSymbols = PianoIndicator.PickSymbols(ModuleType);

        StringBuilder logString = new StringBuilder();
        logString.Append("Module generated with the following symbols: ");
        logString.Append(string.Join(", ", pickedSymbols.Select((x) => x.GetDescription()).ToArray()));

        KMBombModule.Log(logString.ToString());
    }

    private void Update()
    {
        if (_correctDecision == null)
        {
            _correctDecision = SelectDecision();

            StringBuilder logString = new StringBuilder();
            logString.AppendFormat("The correct rule is the following:\n  Symbols: {0}\n  Further Requirements: {1}\n\n", _correctDecision.RequiredSymbolsString, _correctDecision.FurtherRequirementsString);
            logString.Append("The current valid sequence is the following: ");
            logString.AppendFormat("[{0}] ", _correctDecision.SequenceStringHandler(KMBombInfo));
            logString.Append(string.Join(", ", DecisionNotes.Select((x) => x.Semitone.GetDescription()).ToArray()));
            logString.Append("\n");

            KMBombModule.Log(logString.ToString());
        }
    }
    #endregion

    #region Note Hooks
    private void SetupSelectableNote(KMSelectable selectable, Semitone semitone)
    {
        selectable.OnInteract += delegate ()
        {
            ProcessSemitoneHit(semitone);
            return false;
        };
    }
    #endregion

    #region Decision Selection
    private Decision SelectDecision()
    {
        switch (ModuleType)
        {
            case Type.Cruel:
                Decision decision = DecisionDatabase.CruelDecisions.FirstOrDefault((x) => x.IsValidDecision(PianoIndicator, KMBombInfo));
                if (decision != null)
                {
                    return decision;
                }

                //Need to break to fall-through to 'normal' decisions
                break;

            case Type.Festive:
                //Festive doesn't fall-through  to 'normal' decisions
                return DecisionDatabase.FestiveDecisions.FirstOrDefault((x) => x.IsValidDecision(PianoIndicator, KMBombInfo));

            default:
                break;
        }

        return DecisionDatabase.NormalDecisions.FirstOrDefault((x) => x.IsValidDecision(PianoIndicator, KMBombInfo));
    }
    #endregion

    #region Decision Validation
    private void ProcessSemitoneHit(Semitone semitone)
    {
        PlayNote(semitone);

        if (IsMelodyComplete)
        {
            return;
        }

        StringBuilder logString = new StringBuilder();
        logString.Append("The current valid sequence is the following: ");
        logString.AppendFormat("[{0}] ", _correctDecision.SequenceStringHandler(KMBombInfo));
        logString.Append(string.Join(", ", DecisionNotes.Select((x) => x.Semitone.GetDescription()).ToArray()));
        KMBombModule.Log(logString.ToString());
        KMBombModule.LogFormat("Input {0} was received; valid input at this stage is {1}", semitone.GetDescription(), CurrentSemitone.GetDescription());

        if (IsCorrectSemitone(semitone))
        {
            AdvanceCurrentNote();
            if (IsMelodyComplete)
            {
                KMBombModule.Log("Input was valid and sequence complete; module defused!");
                KMBombModule.HandlePass();
            }
            else
            {
                KMBombModule.Log("Input was valid; continuing the sequence...");
            }
        }
        else
        {
            KMBombModule.Log("Input was invalid; module caused a strike and reset!");
            ResetCurrentNote();
            KMBombModule.HandleStrike();
        }
    }

    private bool IsCorrectSemitone(Semitone semitone)
    {
        return CurrentSemitone == semitone;
    }

    private void PlayNote(Semitone semitone)
    {
        PianoPlayer.Play(semitone, CurrentOctave);
    }

    private void ResetCurrentNote()
    {
        _currentNoteIndex = 0;
    }

    private void AdvanceCurrentNote()
    {
        _currentNoteIndex++;
    }

    private bool IsMelodyComplete
    {
        get
        {
            return _currentNoteIndex >= DecisionNotes.Count();
        }
    }

    private Semitone CurrentSemitone
    {
        get
        {
            Note[] notes = DecisionNotes.ToArray();

            if (_correctDecision != null && _currentNoteIndex >= 0 && _currentNoteIndex < notes.Length)
            {
                return notes[_currentNoteIndex].Semitone;
            }

            throw new Exception();
        }
    }

    private int CurrentOctave
    {
        get
        {
            Note[] notes = DecisionNotes.ToArray();

            if (_correctDecision != null && _currentNoteIndex >= 0 && _currentNoteIndex < notes.Length)
            {
                return notes[_currentNoteIndex].Octave;
            }

            return DefaultOctave;
        }
    }
    #endregion

    #region Twitch Plays
    public IEnumerator ProcessTwitchCommand(string command)
    {
        if (command.StartsWith("press ", StringComparison.InvariantCultureIgnoreCase))
        {
            command = command.Substring(5);
        }
        else if (command.StartsWith("play ", StringComparison.InvariantCultureIgnoreCase))
        {
            command = command.Substring(4);
        }
        else
        { 
            yield break;
        }

        string[] sequence = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<Semitone> toPress = new List<Semitone>();

        foreach (string buttonString in sequence)
        {
            switch (buttonString.ToLowerInvariant())
            {
                case "b#":
                case "b♯":
                case "c":
                    toPress.Add(Semitone.C);
                    break;
                case "c#":
                case "c♯":
                case "db":
                case "d♭":
                    toPress.Add(Semitone.CSharp);
                    break;
                case "d":
                    toPress.Add(Semitone.D);
                    break;
                case "d#":
                case "d♯":
                case "eb":
                case "e♭":
                    toPress.Add(Semitone.DSharp);
                    break;
                case "e":
                case "fb":
                case "f♭":
                    toPress.Add(Semitone.E);
                    break;
                case "e#":
                case "e♯":
                case "f":
                    toPress.Add(Semitone.F);
                    break;
                case "f#":
                case "f♯":
                case "gb":
                case "g♭":
                    toPress.Add(Semitone.FSharp);
                    break;
                case "g":
                    toPress.Add(Semitone.G);
                    break;
                case "g#":
                case "g♯":
                case "ab":
                case "a♭":
                    toPress.Add(Semitone.GSharp);
                    break;
                case "a":
                    toPress.Add(Semitone.A);
                    break;
                case "a#":
                case "a♯":
                case "bb":
                case "b♭":
                    toPress.Add(Semitone.ASharp);
                    break;
                case "b":
                case "cb":
                case "c♭":
                    toPress.Add(Semitone.B);
                    break;

                default:
                    yield break;
            }
        }

        float tempoMultiplier = 1.45f; // To make up for yield-related slowness, and speed it up a little in general
        int tempo;

        // Attempt to find a matching melody in the normal database
        Semitone[] inputSemitones = toPress.ToArray();
        foreach (Decision decision in DecisionDatabase.NormalDecisions)
        {
            IEnumerable<Note> notes = decision.GetNotes(KMBombInfo);
            Semitone[] melodySemitones = notes.Select((x) => x.Semitone).ToArray();
            if (inputSemitones.SequenceEqual(melodySemitones))
            {
                tempo = decision.MelodyHandler(KMBombInfo).Tempo;
                KMBombModule.Log("Input matches " + decision.SequenceStringHandler(KMBombInfo) + "; inputting melody");
                foreach (Note note in notes)
                {
                    float duration = note.Duration / tempo * 240 / tempoMultiplier;
                    yield return KMSelectable.Children[(int)note.Semitone];
                    yield return new WaitForSeconds(duration);
                    yield return KMSelectable.Children[(int)note.Semitone];
                }
                yield break;
            }
        }

        // Attempt to find a matching melody in the festive database
        foreach (Decision decision in DecisionDatabase.FestiveDecisions)
        {
            IEnumerable<Note> notes = decision.GetNotes(KMBombInfo);
            Semitone[] melodySemitones = notes.Select((x) => x.Semitone).ToArray();
            if (inputSemitones.SequenceEqual(melodySemitones))
            {
                tempo = decision.MelodyHandler(KMBombInfo).Tempo;
                KMBombModule.Log("Input matches " + decision.SequenceStringHandler(KMBombInfo) + "; inputting melody");
                foreach (Note note in notes)
                {
                    float duration = note.Duration / tempo * 240 / tempoMultiplier;
                    yield return KMSelectable.Children[(int)note.Semitone];
                    yield return new WaitForSeconds(duration);
                    yield return KMSelectable.Children[(int)note.Semitone];
                }
                yield break;
            }
        }

        // No matching melody found
        KMBombModule.Log("Input does not match a known melody; producing a random tempo and rhythm");
        System.Random rng = new System.Random();
        tempo = rng.Next(100, 150);
        foreach (Semitone key in toPress)
        {
            float duration = 1.0f / (float)Math.Pow(2, rng.Next(2, 4)) / tempo * 240 / tempoMultiplier;
            yield return KMSelectable.Children[ (int)key ];
            yield return new WaitForSeconds(duration);
            yield return KMSelectable.Children[ (int)key ];
        }
    }
    #endregion
}
