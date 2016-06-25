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
    //TODO - Put this back when/if KMAudio allows multiple-instance audio playback
    //public KMAudio KMAudio;

    //TODO - Remove this when/if KMAudio allows multiple-instance audio playback
    public AudioSource AudioSource;

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

        //This is the way we're supposed to play sounds using KTANEModKit - it doesn't do multiple-instance audio playback yet
        //KMAudio.PlaySoundAtTransform(Sounds[soundIndex].name, transform);

        //TODO - Remove usage of this audio source when/if KMAudio allows multiple-instance audio playback
        AudioSource.PlayOneShot(Sounds[soundIndex]);
    }

    private int GetSoundIndex(Semitone semitone, int octave)
    {
        int octaveDifference = octave - InitialOctave;
        int semitoneDifference = (int)semitone - (int)InitialSemitone;    
        return (octaveDifference * 12) + semitoneDifference;
    }
}
