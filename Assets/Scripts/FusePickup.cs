/*
* Author: Muhammad Zakir
* Date: 14/05/2026
* Description:
*/

using UnityEngine;
using TMPro;

/// <summary>
/// Manages fuse pickup and updates inventory.
/// </summary>
public class FusePickup : MonoBehaviour
{
    public TextMeshProUGUI interactText;
    public AudioClip pickupSound;

    private bool playerInRange = false;
    private Inventory playerInventory;

    void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Collect fuse when interacted (E)
    /// </summary>
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerInventory.AddFuse();

            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            interactText.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Shows pickup text when player is near
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = other.GetComponent<Inventory>();

            interactText.text = "FUSE\nE to collect";
            interactText.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Hides pickup text when player leaves
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactText.gameObject.SetActive(false);
        }
    }
}