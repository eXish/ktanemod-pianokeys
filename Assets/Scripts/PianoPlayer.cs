using UnityEngine;

public enum Semitone
{
    C,
    CSharp,
    D,
    DSharp,
    E,
    F,
    FSharp,
    G,
    GSharp,
    A,
    ASharp,
    B
}

public class PianoPlayer : MonoBehaviour
{
    public KMAudio KMAudio;

    public Semitone InitialSemitone;
    public int InitialOctave;
    public AudioClip[] Sounds;

    public void Play(Semitone semitone, int octave)
    {
        if (Sounds == null)
        {
            return;
        }

        int soundIndex = GetSoundIndex(semitone, octave);
        if (soundIndex < 0 || soundIndex >= Sounds.Length)
        {
            return;
        }

        KMAudio.PlaySoundAtTransform(Sounds[soundIndex].name, transform);
    }

    private int GetSoundIndex(Semitone semitone, int octave)
    {
        int octaveDifference = octave - InitialOctave;
        int semitoneDifference = (int)semitone - (int)InitialSemitone;    
        return (octaveDifference * 12) + semitoneDifference;
    }
}
