using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;

public class PianoKeysModule : MonoBehaviour
{
    #region Constants
    private const int DefaultOctave = 3;
    private static readonly Color NormalColour = new Color(1.0f, 1.0f, 1.0f);
    private static readonly Color CruelColour = new Color(1.0f, 0.1f, 0.1f);
    #endregion

    #region Public Fields
    public KMBombModule KMBombModule;
    public KMBombInfo KMBombInfo;
    public KMSelectable KMSelectable;
    public MeshRenderer ComponentMesh;
    public PianoPlayer PianoPlayer;
    public PianoIndicator PianoIndicator;
    public bool IsCruel;
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

        SetupMaterial();
        MusicSymbol[] pickedSymbols = PianoIndicator.PickSymbols(IsCruel);

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

    #region Material Setup
    private void SetupMaterial()
    {
        Material newMaterial = new Material(ComponentMesh.material);
        newMaterial.color = IsCruel ? CruelColour : NormalColour;
        ComponentMesh.material = newMaterial;
    }
    #endregion

    #region Decision Selection
    private Decision SelectDecision()
    {
        if (IsCruel)
        {
            Decision decision = DecisionDatabase.CruelDecisions.FirstOrDefault((x) => x.IsValidDecision(PianoIndicator, KMBombInfo));
            if (decision != null)
            {
                return decision;
            }
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
    public KMSelectable[] ProcessTwitchCommand(string command)
    {
        if (!command.StartsWith("press ", StringComparison.InvariantCultureIgnoreCase))
        {
            return null;
        }

        command = command.Substring(5);

        string[] sequence = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<KMSelectable> selectables = new List<KMSelectable>();

        foreach (string buttonString in sequence)
        {
            switch (buttonString.ToLowerInvariant())
            {
                case "c":
                    selectables.Add(KMSelectable.Children[0]);
                    break;
                case "c#":
                case "c♯":
                case "db":
                case "d♭":
                    selectables.Add(KMSelectable.Children[1]);
                    break;
                case "d":
                    selectables.Add(KMSelectable.Children[2]);
                    break;
                case "d#":
                case "d♯":
                case "eb":
                case "e♭":
                    selectables.Add(KMSelectable.Children[3]);
                    break;
                case "e":
                    selectables.Add(KMSelectable.Children[4]);
                    break;
                case "f":
                    selectables.Add(KMSelectable.Children[5]);
                    break;
                case "f#":
                case "f♯":
                case "gb":
                case "g♭":
                    selectables.Add(KMSelectable.Children[6]);
                    break;
                case "g":
                    selectables.Add(KMSelectable.Children[7]);
                    break;
                case "g#":
                case "g♯":
                case "ab":
                case "a♭":
                    selectables.Add(KMSelectable.Children[8]);
                    break;
                case "a":
                    selectables.Add(KMSelectable.Children[9]);
                    break;
                case "a#":
                case "a♯":
                case "bb":
                case "b♭":
                    selectables.Add(KMSelectable.Children[10]);
                    break;
                case "b":
                    selectables.Add(KMSelectable.Children[11]);
                    break;

                default:
                    break;
            }
        }

        return selectables.ToArray();
    }
    #endregion
}
