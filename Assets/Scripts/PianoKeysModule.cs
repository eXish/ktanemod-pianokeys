using System;
using System.Linq;
using UnityEngine;

public class PianoKeysModule : MonoBehaviour
{
    #region Constants
    private const int DefaultOctave = 3;
    #endregion

    #region Public Fields
    public KMBombModule KMBombModule;
    public KMBombInfo KMBombInfo;
    public KMSelectable KMSelectable;
    public PianoPlayer PianoPlayer;
    public PianoIndicator PianoIndicator;
    #endregion

    #region Private Fields
    private static readonly Melody[] Melodies =
    {
        new Melody() {
            Name = "Final Fantasy Victory Fanfare",
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Flat) && (bombInfo.GetSerialNumberNumbers().Last() % 2) == 0,
            Notes = new Note[] { new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.FSharp, 3),
                                 new Note(Semitone.GSharp, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.GSharp, 3),
                                 new Note(Semitone.ASharp, 3)
            }
        },

        new Melody() {
            Name = "Guile's Theme",
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CommonTime) || indicator.HasSymbol(MusicSymbol.Sharp)) && bombInfo.GetBatteryHolderCount() >= 2,
            Notes = new Note[] { new Note(Semitone.DSharp, 3),
                                 new Note(Semitone.DSharp, 3),
                                 new Note(Semitone.D, 3),
                                 new Note(Semitone.D, 3),
                                 new Note(Semitone.DSharp, 3),
                                 new Note(Semitone.DSharp, 3),
                                 new Note(Semitone.D, 3),
                                 new Note(Semitone.DSharp, 3),
                                 new Note(Semitone.DSharp, 3),
                                 new Note(Semitone.D, 3),
                                 new Note(Semitone.D, 3),
                                 new Note(Semitone.DSharp, 3)
            }
        },

        new Melody() {
            Name = "James Bond Theme",
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Natural) && indicator.HasSymbol(MusicSymbol.Fermata),
            Notes = new Note[] { new Note(Semitone.E, 3),
                                 new Note(Semitone.FSharp, 3),
                                 new Note(Semitone.FSharp, 3),
                                 new Note(Semitone.FSharp, 3),
                                 new Note(Semitone.FSharp, 3),
                                 new Note(Semitone.E, 3),
                                 new Note(Semitone.E, 3),
                                 new Note(Semitone.E, 3)
            }
        },

        new Melody() {
            Name = "Jurassic Park Theme",
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CutCommonTime) || indicator.HasSymbol(MusicSymbol.Turn)) && bombInfo.IsPortPresent(KMBombInfoExtensions.KnownPortType.StereoRCA),
            Notes = new Note[] { new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.A, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.F, 3),
                                 new Note(Semitone.DSharp, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.A, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.F, 3),
                                 new Note(Semitone.DSharp, 3)
            }
        },

        new Melody() {
            Name = "Mario Bros. Overworld Theme",
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.AltoClef) && bombInfo.IsIndicatorOn(KMBombInfoExtensions.KnownIndicatorLabel.SND),
            Notes = new Note[] { new Note(Semitone.E, 3),
                                 new Note(Semitone.E, 3),
                                 new Note(Semitone.E, 3),
                                 new Note(Semitone.C, 3),
                                 new Note(Semitone.E, 3),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.G, 2)
            }
        },

        new Melody() {
            Name = "The Pink Panther Theme",
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Mordent) || indicator.HasSymbol(MusicSymbol.Fermata) || indicator.HasSymbol(MusicSymbol.CommonTime)) && bombInfo.GetBatteryCount() >= 3,
            Notes = new Note[] { new Note(Semitone.CSharp, 3),
                                 new Note(Semitone.D, 3),
                                 new Note(Semitone.E, 3),
                                 new Note(Semitone.F, 3),
                                 new Note(Semitone.CSharp, 3),
                                 new Note(Semitone.D, 3),
                                 new Note(Semitone.E, 3),
                                 new Note(Semitone.F, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.A, 3)
            }
        },

        new Melody() {
            Name = "Superman Theme",
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Flat) && indicator.HasSymbol(MusicSymbol.Sharp),
            Notes = new Note[] { new Note(Semitone.G, 3),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.C, 3),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.C, 4),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.C, 3)
            }
        },

        new Melody() {
            Name = "Tetris Mode-A Theme",
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CutCommonTime) || indicator.HasSymbol(MusicSymbol.Mordent)) && bombInfo.GetSerialNumberNumbers().Any((x) => x == 3 || x == 7 || x == 8),
            Notes = new Note[] { new Note(Semitone.A, 3),
                                 new Note(Semitone.E, 3),
                                 new Note(Semitone.F, 3),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.F, 3),
                                 new Note(Semitone.E, 3),
                                 new Note(Semitone.D, 3),
                                 new Note(Semitone.D, 3),
                                 new Note(Semitone.F, 3),
                                 new Note(Semitone.A, 3)
            }
        },

        new Melody() {
            Name = "The Empire Strikes Back Theme",
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Natural) || indicator.HasSymbol(MusicSymbol.Turn) || indicator.HasSymbol(MusicSymbol.AltoClef),
            Notes = new Note[] { new Note(Semitone.G, 3),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.DSharp, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.DSharp, 3),
                                 new Note(Semitone.ASharp, 3),
                                 new Note(Semitone.G, 3)
            }
        },

        new Melody() {
            Name = "Zelda's Lullaby Theme",
            RuleHandler = (indicator, bombInfo) => true,
            Notes = new Note[] { new Note(Semitone.B, 3),
                                 new Note(Semitone.D, 4),
                                 new Note(Semitone.A, 3),
                                 new Note(Semitone.G, 3),
                                 new Note(Semitone.A, 3),
                                 new Note(Semitone.B, 3),
                                 new Note(Semitone.D, 4),
                                 new Note(Semitone.A, 3)
            }
        },
    };
    private Melody _correctMelody = null;
    private int _currentNoteIndex = 0;
    #endregion

    #region Unity Lifetime
    private void Start()
    {
        for(int childIndex = 0; childIndex < KMSelectable.Children.Length; ++childIndex)
        {
            KMSelectable childSelectable = KMSelectable.Children[childIndex];
            SetupSelectableNote(childSelectable, (Semitone)childIndex);
        }
    }

    private void Update()
    {
        if (_correctMelody == null)
        {
            _correctMelody = SelectMelody();
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

    #region Melody Selection
    private Melody SelectMelody()
    {
        foreach (Melody melody in Melodies)
        {
            if (melody.RuleHandler(PianoIndicator, KMBombInfo))
            {
                return melody;
            }
        }

        return null;
    }
    #endregion

    #region Melody Validation
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
            return _currentNoteIndex >= _correctMelody.Notes.Length;
        }
    }

    private Semitone CurrentSemitone
    {
        get
        {
            if (_correctMelody != null && _currentNoteIndex >= 0 && _currentNoteIndex < _correctMelody.Notes.Length)
            {
                return _correctMelody.Notes[_currentNoteIndex].Semitone;
            }

            throw new Exception();
        }
    }

    private int CurrentOctave
    {
        get
        {
            if (_correctMelody != null && _currentNoteIndex >= 0 && _currentNoteIndex < _correctMelody.Notes.Length)
            {
                return _correctMelody.Notes[_currentNoteIndex].Octave;
            }

            return DefaultOctave;
        }
    }
    #endregion
}
