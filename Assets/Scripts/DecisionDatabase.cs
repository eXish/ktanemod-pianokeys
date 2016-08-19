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
            TransformationHandler = (sequence, bombInfo) => sequence
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CommonTime) || indicator.HasSymbol(MusicSymbol.Sharp)) && bombInfo.GetBatteryHolderCount() >= 2,
            MelodyHandler = (bombInfo) => MelodyDatabase.GuilesTheme,
            TransformationHandler = (sequence, bombInfo) => sequence
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Natural) && indicator.HasSymbol(MusicSymbol.Fermata),
            MelodyHandler = (bombInfo) => MelodyDatabase.JamesBond,
            TransformationHandler = (sequence, bombInfo) => sequence
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CutCommonTime) || indicator.HasSymbol(MusicSymbol.Turn)) && bombInfo.IsPortPresent(KMBombInfoExtensions.KnownPortType.StereoRCA),
            MelodyHandler = (bombInfo) => MelodyDatabase.JurrasicPark,
            TransformationHandler = (sequence, bombInfo) => sequence
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.AltoClef) && bombInfo.IsIndicatorOn(KMBombInfoExtensions.KnownIndicatorLabel.SND),
            MelodyHandler = (bombInfo) => MelodyDatabase.SuperMarioBros,
            TransformationHandler = (sequence, bombInfo) => sequence
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Mordent) || indicator.HasSymbol(MusicSymbol.Fermata) || indicator.HasSymbol(MusicSymbol.CommonTime)) && bombInfo.GetBatteryCount() >= 3,
            MelodyHandler = (bombInfo) => MelodyDatabase.PinkPanther,
            TransformationHandler = (sequence, bombInfo) => sequence
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Flat) && indicator.HasSymbol(MusicSymbol.Sharp),
            MelodyHandler = (bombInfo) => MelodyDatabase.Superman,
            TransformationHandler = (sequence, bombInfo) => sequence
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CutCommonTime) || indicator.HasSymbol(MusicSymbol.Mordent)) && bombInfo.GetSerialNumberNumbers().Any((x) => x == 3 || x == 7 || x == 8),
            MelodyHandler = (bombInfo) => MelodyDatabase.TetrisA,
            TransformationHandler = (sequence, bombInfo) => sequence
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Natural) || indicator.HasSymbol(MusicSymbol.Turn) || indicator.HasSymbol(MusicSymbol.AltoClef),
            MelodyHandler = (bombInfo) => MelodyDatabase.EmpireStrikesBack,
            TransformationHandler = (sequence, bombInfo) => sequence
        },

        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => true,
            MelodyHandler = (bombInfo) => MelodyDatabase.ZeldasLullaby,
            TransformationHandler = (sequence, bombInfo) => sequence
        }
    };

    public static readonly Decision[] CruelDecisions =
    {
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Breeve) && indicator.HasSymbol(MusicSymbol.Turn) && bombInfo.GetIndicators().Count() >= 2,
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetSerialNumberNumbers().First()],
            TransformationHandler = (sequence, bombInfo) => sequence.Inversion().Retrograde().Transpose(2)
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Sharp) || indicator.HasSymbol(MusicSymbol.DoubleSharp)) && bombInfo.GetPortPlates().Any((x) => x.Length == 0),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetBatteryHolderCount()],
            TransformationHandler = (sequence, bombInfo) => sequence.Transpose(-Mathf.FloorToInt(bombInfo.GetTime() / 60.0f))
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Fermata) || indicator.HasSymbol(MusicSymbol.DownBow)) && bombInfo.GetPorts().GroupBy((x) => x).Any((y) => y.Count() >= 2),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetSolvedModuleNames().Count % 10],
            TransformationHandler = (sequence, bombInfo) => sequence.Retrograde()
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.AltoClef) && indicator.HasSymbol(MusicSymbol.SemiquaverRest) && bombInfo.GetPortPlateCount() >= 2,
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[9 - bombInfo.GetOffIndicators().Count()],
            TransformationHandler = (sequence, bombInfo) => sequence.Inversion().Retrograde()
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.CutCommonTime) || indicator.HasSymbol(MusicSymbol.CommonTime)) && bombInfo.GetSerialNumber().HasVowel(),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetStrikes() % 10],
            TransformationHandler = (sequence, bombInfo) => sequence.Retrograde().Transpose(-3)
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Natural) || indicator.HasSymbol(MusicSymbol.Mordent)) && (bombInfo.GetBatteryCount() % 2) == 0,
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[bombInfo.GetPortCount(KMBombInfoExtensions.KnownPortType.DVI) > 0 ? 7 : 3],
            TransformationHandler = (sequence, bombInfo) => sequence.Transpose(bombInfo.GetPortCount())
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.Flat) || indicator.HasSymbol(MusicSymbol.CrotchetRest)) && bombInfo.GetIndicators().Any((x) => !x.HasVowel()),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[8],
            TransformationHandler = (sequence, bombInfo) => sequence.Inversion()
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => (indicator.HasSymbol(MusicSymbol.DownBow) || indicator.HasSymbol(MusicSymbol.SemiquaverRest)) && bombInfo.GetPortCount() < 2,
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[4],
            TransformationHandler = (sequence, bombInfo) => sequence.Retrograde()
        },
        new Decision()
        {
            RuleHandler = (indicator, bombInfo) => indicator.HasSymbol(MusicSymbol.Breeve) || indicator.HasSymbol(MusicSymbol.DoubleSharp),
            MelodyHandler = (bombInfo) => MelodyDatabase.SerialismMelodies[5],
            TransformationHandler = (sequence, bombInfo) => sequence
        }
    };
}
