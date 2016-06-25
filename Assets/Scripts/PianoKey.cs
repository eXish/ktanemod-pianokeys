using UnityEngine;

public class PianoKey : MonoBehaviour
{
    public KMSelectable KMSelectable;
    public Animator Animator;

	void Start ()
    {
        KMSelectable.OnInteract += delegate ()
        {
            Animator.SetTrigger("PressTrigger");
            return false;
        };
	}
}
