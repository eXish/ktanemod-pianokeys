using System.Linq;
using System.Collections.Generic;

public class Note
{
    public Note(Semitone semitone, int octave, float duration = 0.125f)
    {
        Semitone = semitone;
        Octave = octave;
        Duration = duration;
    }

    public Semitone Semitone;
    public int Octave;
    public float Duration;
}

public class Melody
{
    public string Name;
    public Note[] Notes;
    public int Tempo = 130;

    public override string ToString()
    {
        return Name;
    }
}

public delegate bool RuleDelegate(PianoIndicator pianoIndicator, KMBombInfo bombInfo);
public delegate Melody MelodyDelegate(KMBombInfo bombInfo);
public delegate IEnumerable<Note> TransformationDelegate(IEnumerable<Note> sourceMelody, KMBombInfo bombInfo);
public delegate string SequenceStringDelegate(KMBombInfo bombInfo);

public static class NoteExtensions
{
    public static IEnumerable<Note> Retrograde(this IEnumerable<Note> sequence)
    {
        return sequence.Reverse();
    }

    public static IEnumerable<Note> Inversion(this IEnumerable<Note> sequence)
    {
        int currentValue = -1;
        int lastSourceValue = -1;

        foreach(Note note in sequence)
        {
            int thisSourceValue = (int)note.Semitone;

            if (lastSourceValue != -1)
            {
                int inversionDifference = lastSourceValue - thisSourceValue;
                currentValue += inversionDifference;
                while (currentValue < 0)
                {
                    currentValue += 12;
                }
                currentValue %= 12;
            }
            else
            {
                currentValue = thisSourceValue;
            }

            lastSourceValue = thisSourceValue;

            yield return new Note((Semitone)currentValue, note.Octave);
        }
    }

    public static IEnumerable<Note> Transpose(this IEnumerable<Note> sequence, int shift)
    {
        foreach(Note note in sequence)
        {
            int currentValue = ((int)note.Semitone) + shift;
            while(currentValue < 0)
            {
                currentValue += 12;
            }
            currentValue %= 12;

            yield return new Note((Semitone)currentValue, note.Octave);
        }
    }
}

public class Decision
{
    public MelodyDelegate MelodyHandler;
    public RuleDelegate RuleHandler;
    public TransformationDelegate TransformationHandler;
    public string RequiredSymbolsString;
    public string FurtherRequirementsString;
    public SequenceStringDelegate SequenceStringHandler;

    public bool IsValidDecision(PianoIndicator pianoIndicator, KMBombInfo bombInfo)
    {
        return RuleHandler(pianoIndicator, bombInfo);
    }

    public IEnumerable<Note> GetNotes(KMBombInfo bombInfo)
    {
        return TransformationHandler(MelodyHandler(bombInfo).Notes, bombInfo);
    }
}
