using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    private bool isOpen = false;

    public void OpenDoor()
    {
        if (isOpen) return;

        isOpen = true;
        doorAnimator.SetBool("IsOpen", true);

        if (openSound != null)
            audioSource.PlayOneShot(openSound);
    }

    public void CloseDoor()
    {
        if (!isOpen) return;

        isOpen = false;
        doorAnimator.SetBool("IsOpen", false);
        audioSource.PlayOneShot(closeSound);
    }

    public void ToggleDoor()
    {
        OpenDoor();
    }
}