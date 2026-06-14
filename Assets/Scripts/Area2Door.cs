using UnityEngine;
using TMPro;

/// <summary>
/// Area 2 gate requirements and interaction
/// </summary>
public class Area2Door : MonoBehaviour
{
    public DoorController doorController;
    public Inventory playerInventory;
    public TextMeshProUGUI interactText;

    private bool playerInRange = false;

    void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    /// <summary>
    /// check for requirements
    /// </summary>
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory.hasKeycard && playerInventory.generatorRepaired)
            {
                doorController.OpenDoor();
                interactText.gameObject.SetActive(false);
            }
            else if (!playerInventory.hasKeycard && !playerInventory.generatorRepaired)
            {
                interactText.text = "Need Keycard and Generator";
            }
            else if (!playerInventory.hasKeycard)
            {
                interactText.text = "Need Keycard";
            }
            else if (!playerInventory.generatorRepaired)
            {
                interactText.text = "Generator Not Repaired";
            }
        }
    }

    /// <summary>
    /// Shows interaction text when player is near
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            interactText.text = "AREA 2 GATE\nE to interact";
            interactText.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Hides interaction text when player leaves
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