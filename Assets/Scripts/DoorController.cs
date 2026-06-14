/*
* Author: Muhammad Zakir
* Date: 14/05/2026
* Description:
*/

using UnityEngine;

/// <summary>
/// Manages door opening/closing/sounds
/// </summary>
public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private bool stayOpen = false;

    private bool isOpen = false;

    /// <summary>
    /// Opens the door and plays open sound
    /// </summary>
    public void OpenDoor()
    {
        if (isOpen) return;

        isOpen = true;
        doorAnimator.SetBool("IsOpen", true);

        if (audioSource != null && openSound != null)
        {
            audioSource.PlayOneShot(openSound);
        }
    }

    /// <summary>
    /// Closes the door and plays close sound
    /// </summary>
    public void CloseDoor()
    {
        if (!isOpen) return;
        if (stayOpen) return;

        isOpen = false;
        doorAnimator.SetBool("IsOpen", false);

        if (audioSource != null && closeSound != null)
        {
            audioSource.PlayOneShot(closeSound);
        }
    }

    /// <summary>
    /// Opens door when interacted (e)
    /// </summary>
    public void ToggleDoor()
    {
        OpenDoor();
    }
}