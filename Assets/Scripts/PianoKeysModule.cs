using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

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
    public KMModSettings KMModSettings;
    public MeshRenderer ComponentMesh;
    public PianoPlayer PianoPlayer;
    public PianoIndicator PianoIndicator;
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
    private bool _isCruel = false;
    #endregion

    #region Unity Lifetime
    private void Start()
    {
        for (int childIndex = 0; childIndex < KMSelectable.Children.Length; ++childIndex)
        {
            KMSelectable childSelectable = KMSelectable.Children[childIndex];
            SetupSelectableNote(childSelectable, (Semitone)childIndex);
        }

        _isCruel = GenerateCruelness();

        KMBombModule.ModuleDisplayName = _isCruel ? "Cruel Piano Keys" : "Piano Keys";
        KMBombModule.ModuleType = _isCruel ? "CruelPianoKeys" : "PianoKeys";

        SetupMaterial();
        PianoIndicator.PickSymbols(_isCruel);
    }

    private void Update()
    {
        if (_correctDecision == null)
        {
            _correctDecision = SelectDecision();
        }
    }
    #endregion

    #region Cruel Decider
    private bool GenerateCruelness()
    {
        try
        {
            PianoKeysModSettings modSettings = JsonConvert.DeserializeObject<PianoKeysModSettings>(KMModSettings.Settings);
            if (modSettings != null)
            {
                return UnityEngine.Random.Range(0.0001f, 1.0f) <= modSettings.CruelProbability;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
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
        newMaterial.color = _isCruel ? CruelColour : NormalColour;
        ComponentMesh.material = newMaterial;
    }
    #endregion

    #region Decision Selection
    private Decision SelectDecision()
    {
        if (_isCruel)
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

        if (IsCorrectSemitone(semitone))
        {
            AdvanceCurrentNote();
            if (IsMelodyComplete)
            {
                KMBombModule.HandlePass();
            }
        }
        else
        {
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
}
