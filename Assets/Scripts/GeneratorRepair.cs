using UnityEngine;
using TMPro;

/// <summary>
/// Manages generator repair if player = 5 fuses
/// </summary>
public class GeneratorRepair : MonoBehaviour
{
    public bool generatorRepaired = false;

    public TextMeshProUGUI promptText;

    private bool playerInRange = false;
    private Inventory playerInventory;

    void Start()
    {
        promptText.gameObject.SetActive(false);
    }

    /// <summary>
    /// if player has 5 fuses, repair generator
    /// </summary>
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory.fuseCount >= 5)
            {
                generatorRepaired = true;
                playerInventory.RepairGenerator();

                promptText.text = "Generator repaired.";
                Debug.Log("Generator repaired");
            }
            else
            {
                promptText.text = "Need 5 fuses to repair generator.";
            }
        }
    }

    /// <summary>
    /// Shows repair text when player is near.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = other.GetComponent<Inventory>();

            promptText.text = "Press E to repair generator";
            promptText.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Hides repair text when player leaves
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            promptText.gameObject.SetActive(false);
        }
    }
}