using System.Linq;
using UnityEngine;

public static class DecisionDatabase
{
    public static readonly Decision[] NormalDecisions =
    {
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Flat) && (bombInfo.GetSerialNumberNumbers().Last() % 2) == 0,
            MelodyHandler = (bombInfo) => MelodyDatabase.FinalFantasyVictory,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = MusicSymbol.Flat.GetDescription(),
            FurtherRequirementsString = "Last digit of serial number is even",
            SequenceStringHandler = (bombInfo) => "'Final Fantasy Victory'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CommonTime) || indicator.HasSymbol(MusicSymbol.Sharp)) && bombInfo.GetBatteryHolderCount() >= 2,
            MelodyHandler = (bombInfo) => MelodyDatabase.GuilesTheme,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.CommonTime.GetDescription(), MusicSymbol.Sharp.GetDescription()),
            FurtherRequirementsString = "2 or more battery holders",
            SequenceStringHandler = (bombInfo) => "'Guile's Theme'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Natural) && indicator.HasSymbol(MusicSymbol.Fermata),
            MelodyHandler = (bombInfo) => MelodyDatabase.JamesBond,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} and {1}", MusicSymbol.Natural.GetDescription(), MusicSymbol.Fermata.GetDescription()),
            FurtherRequirementsString = "(No other requirements)",
            SequenceStringHandler = (bombInfo) => "'James Bond'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CutCommonTime) || indicator.HasSymbol(MusicSymbol.Turn)) && bombInfo.IsPortPresent(KMBombInfoExtensions.KnownPortType.StereoRCA),
            MelodyHandler = (bombInfo) => MelodyDatabase.JurrasicPark,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} and {1}", MusicSymbol.CutCommonTime.GetDescription(), MusicSymbol.Turn.GetDescription()),
            FurtherRequirementsString = "RCA port is present",
            SequenceStringHandler = (bombInfo) => "'Jurrasic Park'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.CClef) && bombInfo.IsIndicatorOn(KMBombInfoExtensions.KnownIndicatorLabel.SND),
            MelodyHandler = (bombInfo) => MelodyDatabase.SuperMarioBros,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = MusicSymbol.CClef.GetDescription(),
            FurtherRequirementsString = "SND indicator is present and lit",
            SequenceStringHandler = (bombInfo) => "'Super Mario Bros.'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Mordent) || indicator.HasSymbol(MusicSymbol.Fermata) || indicator.HasSymbol(MusicSymbol.CommonTime)) && bombInfo.GetBatteryCount() >= 3,
            MelodyHandler = (bombInfo) => MelodyDatabase.PinkPanther,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} or {1} or {2}", MusicSymbol.Mordent.GetDescription(), MusicSymbol.Fermata.GetDescription(), MusicSymbol.CommonTime.GetDescription()),
            FurtherRequirementsString = "3 or more batteries",
            SequenceStringHandler = (bombInfo) => "'Pink Panther'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Flat) && indicator.HasSymbol(MusicSymbol.Sharp),
            MelodyHandler = (bombInfo) => MelodyDatabase.Superman,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} and {1}", MusicSymbol.Flat.GetDescription(), MusicSymbol.Sharp.GetDescription()),
            FurtherRequirementsString = "(No other requirements)",
            SequenceStringHandler = (bombInfo) => "'Superman'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CutCommonTime) || indicator.HasSymbol(MusicSymbol.Mordent)) && bombInfo.GetSerialNumberNumbers().Any((x) => x == 3 || x == 7 || x == 8),
            MelodyHandler = (bombInfo) => MelodyDatabase.TetrisA,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.CutCommonTime.GetDescription(), MusicSymbol.Mordent.GetDescription()),
            FurtherRequirementsString = "Serial number contains a 3, 7 or 8",
            SequenceStringHandler = (bombInfo) => "'Tetris Theme A'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Natural) || indicator.HasSymbol(MusicSymbol.Turn) || indicator.HasSymbol(MusicSymbol.CClef),
            MelodyHandler = (bombInfo) => MelodyDatabase.EmpireStrikesBack,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} or {1} or {2}", MusicSymbol.Natural.GetDescription(), MusicSymbol.Turn.GetDescription(), MusicSymbol.CClef.GetDescription()),
            FurtherRequirementsString = "(No other requirements)",
            SequenceStringHandler = (bombInfo) => "'Empire Strikes Back'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => true,
            MelodyHandler = (bombInfo) => MelodyDatabase.ZeldasLullaby,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = "(No requirement)",
            FurtherRequirementsString = "(No other requirements)",
            SequenceStringHandler = (bombInfo) => "'Zelda's Lullaby'",
        }
    };

    public static readonly Decision[] CruelDecisions =
    {
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Breve) && indicator.HasSymbol(MusicSymbol.Turn) && bombInfo.GetIndicators().Count() >= 2,
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetSerialNumberNumbers().First()],
            TransformationHandler = (sequence, bombInfo) => sequence.Inversion().Retrograde(),
            RequiredSymbolsString = string.Format("{0} and {1}", MusicSymbol.Breve.GetDescription(), MusicSymbol.Turn.GetDescription()),
            FurtherRequirementsString = "2 or more indiciators (lit or unlit)",
            SequenceStringHandler = (bombInfo) => string.Format("RI of #{0}", bombInfo.GetSerialNumberNumbers().First())
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Sharp) || indicator.HasSymbol(MusicSymbol.DoubleSharp)) && bombInfo.GetPortPlates().Any((x) => x.Length == 0),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetBatteryHolderCount() % 10],
            TransformationHandler = (sequence, bombInfo) => sequence.Transpose(-Mathf.FloorToInt(bombInfo.GetTime() / 60.0f)),
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.Sharp.GetDescription(), MusicSymbol.DoubleSharp.GetDescription()),
            FurtherRequirementsString = "An empty port plate",
            SequenceStringHandler = (bombInfo) => string.Format("P -{0} semitones of #{1}", Mathf.FloorToInt(bombInfo.GetTime() / 60.0f), bombInfo.GetBatteryHolderCount() % 10)
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Fermata) || indicator.HasSymbol(MusicSymbol.DownBow)) && bombInfo.GetPorts().GroupBy((x) => x).Any((y) => y.Count() >= 2),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetSolvedModuleNames().Count % 10],
            TransformationHandler = (sequence, bombInfo) => sequence.Inversion(),
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.Fermata.GetDescription(), MusicSymbol.DownBow.GetDescription()),
            FurtherRequirementsString = "2 or more of a certain type of port",
            SequenceStringHandler = (bombInfo) => string.Format("I of #{0}", bombInfo.GetSolvedModuleNames().Count % 10)
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.CClef) && indicator.HasSymbol(MusicSymbol.SemiquaverRest) && bombInfo.GetPortPlateCount() >= 2,
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[9 - (bombInfo.GetOffIndicators().Count() % 10)],
            TransformationHandler = (sequence, bombInfo) => sequence.Retrograde(),
            RequiredSymbolsString = string.Format("{0} and {1}", MusicSymbol.CClef.GetDescription(), MusicSymbol.SemiquaverRest.GetDescription()),
            FurtherRequirementsString = "2 or more port plates",
            SequenceStringHandler = (bombInfo) => string.Format("R of #{0}", 9 - (bombInfo.GetOffIndicators().Count() % 10))
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CutCommonTime) || indicator.HasSymbol(MusicSymbol.CommonTime)) && bombInfo.GetSerialNumber().HasVowel(),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetStrikes() % 10],
            TransformationHandler = (sequence, bombInfo) => sequence.Retrograde().Transpose(-3),
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.CutCommonTime.GetDescription(), MusicSymbol.CommonTime.GetDescription()),
            FurtherRequirementsString = "Serial contains 1 or more vowels",
            SequenceStringHandler = (bombInfo) => string.Format("R -3 of #{0}", bombInfo.GetStrikes() % 10)
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Natural) || indicator.HasSymbol(MusicSymbol.Mordent)) && (bombInfo.GetBatteryCount() % 2) == 0,
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetPortCount(KMBombInfoExtensions.KnownPortType.DVI) > 0 ? 7 : 3],
            TransformationHandler = (sequence, bombInfo) => sequence.Transpose(bombInfo.GetPortCount()),
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.Natural.GetDescription(), MusicSymbol.Mordent.GetDescription()),
            FurtherRequirementsString = "Even number of batteries",
            SequenceStringHandler = (bombInfo) => string.Format("P +{0} of #{1}", bombInfo.GetPortCount(), bombInfo.GetPortCount(KMBombInfoExtensions.KnownPortType.DVI) > 0 ? 7 : 3)
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Flat) || indicator.HasSymbol(MusicSymbol.CrotchetRest)) && bombInfo.GetIndicators().Any((x) => !x.HasVowel()),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[8],
            TransformationHandler = (sequence, bombInfo) => sequence.Inversion(),
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.Flat.GetDescription(), MusicSymbol.CrotchetRest.GetDescription()),
            FurtherRequirementsString = "An indicator with no vowels in the label",
            SequenceStringHandler = (bombInfo) => "I of #8"
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.DownBow) || indicator.HasSymbol(MusicSymbol.SemiquaverRest)) && bombInfo.GetPortCount() < 2,
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[4],
            TransformationHandler = (sequence, bombInfo) => sequence.Retrograde(),
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.DownBow.GetDescription(), MusicSymbol.SemiquaverRest.GetDescription()),
            FurtherRequirementsString = "Less than 2 ports",
            SequenceStringHandler = (bombInfo) => "R of #4"
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Breve) || indicator.HasSymbol(MusicSymbol.DoubleSharp),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[5],
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.Breve.GetDescription(), MusicSymbol.DoubleSharp.GetDescription()),
            FurtherRequirementsString = "(No other requirements)",
            SequenceStringHandler = (bombInfo) => "P of #5"
        }
    };

    public static readonly Decision[] FestiveDecisions =
    {
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Caesura) && bombInfo.GetSerialNumberNumbers().Where((x) => x % 2 == 0).Count() > bombInfo.GetSerialNumberNumbers().Where((x) => x % 2 != 0).Count(),
            MelodyHandler = (bombInfo) => MelodyDatabase.Rudolph,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString =  MusicSymbol.Caesura.GetDescription(),
            FurtherRequirementsString = "More even digits in the serial number than odd",
            SequenceStringHandler = (bombInfo) => "'Rudolph The Red-Nosed Reindeer'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.DalSegno) || indicator.HasSymbol(MusicSymbol.SemiquaverNote)) && bombInfo.GetSerialNumberLetters().GroupBy((x) => x).Any((y) => y.Count() >= 2),
            MelodyHandler = (bombInfo) => MelodyDatabase.WeThreeKings,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString =  string.Format("{0} or {1}", MusicSymbol.DalSegno.GetDescription(), MusicSymbol.SemiquaverNote.GetDescription()),
            FurtherRequirementsString = "Any duplicate characters or digits in serial number",
            SequenceStringHandler = (bombInfo) => "'We Three Kings Of Orient Are'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Mordent) && indicator.HasSymbol(MusicSymbol.PedalUp),
            MelodyHandler = (bombInfo) => MelodyDatabase.SilentNight,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString =  string.Format("{0} and {1}", MusicSymbol.Mordent.GetDescription(), MusicSymbol.PedalUp.GetDescription()),
            FurtherRequirementsString = "(No other requirements)",
            SequenceStringHandler = (bombInfo) => "'Silent Night'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.UpBow) || indicator.HasSymbol(MusicSymbol.DownBow)) && bombInfo.GetPorts().GroupBy((x) => x).Count() <= 2,
            MelodyHandler = (bombInfo) => MelodyDatabase.LastChristmas,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString =  string.Format("{0} or {1}", MusicSymbol.UpBow.GetDescription(), MusicSymbol.DownBow.GetDescription()),
            FurtherRequirementsString = "At most 2 types of port",
            SequenceStringHandler = (bombInfo) => "'Last Christmas'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Marcato) && bombInfo.GetOnIndicators().Any((x) => x.HasVowel()),
            MelodyHandler = (bombInfo) => MelodyDatabase.AllIWantForChristmas,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = MusicSymbol.Marcato.GetDescription(),
            FurtherRequirementsString = "Lit indicator with vowel",
            SequenceStringHandler = (bombInfo) => "'All I Want For Christmas Is You'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.SemiquaverRest) || indicator.HasSymbol(MusicSymbol.SemiquaverNote)) && bombInfo.GetBatteryCount(KMBombInfoExtensions.KnownBatteryType.AAx2) + bombInfo.GetBatteryCount(KMBombInfoExtensions.KnownBatteryType.AAx3) + bombInfo.GetBatteryCount(KMBombInfoExtensions.KnownBatteryType.AAx4) >= 3,
            MelodyHandler = (bombInfo) => MelodyDatabase.MostWonderfulTime,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} or {1}", MusicSymbol.SemiquaverRest.GetDescription(), MusicSymbol.SemiquaverNote.GetDescription()),
            FurtherRequirementsString = "3 or more AA batteries",
            SequenceStringHandler = (bombInfo) => "'Most Wonderful Time of The Year'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.SemibreveNote) && indicator.HasSymbol(MusicSymbol.Breve),
            MelodyHandler = (bombInfo) => MelodyDatabase.FrostyTheSnowman,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} and {1}", MusicSymbol.SemibreveNote.GetDescription(), MusicSymbol.Breve.GetDescription()),
            FurtherRequirementsString = "(No other requirements)",
            SequenceStringHandler = (bombInfo) => "'Frosty The Snowman'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Accent) || indicator.HasSymbol(MusicSymbol.Marcato) || indicator.HasSymbol(MusicSymbol.UpBow)) && bombInfo.GetSerialNumberNumbers().Any((x) => x == 1 || x == 9),
            MelodyHandler = (bombInfo) => MelodyDatabase.JingleBells,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} or {1} or {2}", MusicSymbol.Accent.GetDescription(), MusicSymbol.Marcato.GetDescription(), MusicSymbol.UpBow.GetDescription()),
            FurtherRequirementsString = "Serial number contains 1 or 9",
            SequenceStringHandler = (bombInfo) => "'Jingle Bells'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.DalSegno) || indicator.HasSymbol(MusicSymbol.CClef) || indicator.HasSymbol(MusicSymbol.Caesura),
            MelodyHandler = (bombInfo) => MelodyDatabase.JingleBellRock,
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = string.Format("{0} or {1} or {2}", MusicSymbol.DalSegno.GetDescription(), MusicSymbol.CClef.GetDescription(), MusicSymbol.Caesura.GetDescription()),
            FurtherRequirementsString = "(No other requirements)",
            SequenceStringHandler = (bombInfo) => "'Jingle Bell Rock'",
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => true,
            MelodyHandler = (bombInfo) => MelodyDatabase.GenerateCarolOfTheBells(bombInfo.GetSerialNumberNumbers().Max() + 1),
            TransformationHandler = (sequence, bombInfo) => sequence,
            RequiredSymbolsString = "(No requirement)",
            FurtherRequirementsString = "(No other requirements)",
            SequenceStringHandler = (bombInfo) => string.Format("'Carol of The Bells' x{0}", bombInfo.GetSerialNumberNumbers().Max() + 1),
        },
    };
}
