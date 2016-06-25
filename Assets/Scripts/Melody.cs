using System;
using UnityEngine;

public class Note
{
    public Note(Semitone semitone, int octave)
    {
        Semitone = semitone;
        Octave = octave;
    }

    public Semitone Semitone;
    public int Octave;
}

public delegate bool RuleDelegate(PianoIndicator pianoIndicator, KMBombInfo bombInfo);

public class Melody
{
    public string Name;
    public RuleDelegate RuleHandler;
    public Note[] Notes;

    public override string ToString()
    {
        return Name;
    }
}
