using UnityEngine;
using TMPro;

/// <summary>
/// keycard pickup/inventory update
/// </summary>
public class KeycardPickup : MonoBehaviour
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
    /// Collect keycard (E)
    /// </summary>
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerInventory.AddKeycard();

            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            interactText.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Shows pickup text when player is nearby
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = other.GetComponent<Inventory>();

            interactText.text = "KEYCARD\nE to collect";
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