using UnityEngine;
using TMPro;

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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            promptText.gameObject.SetActive(false);
        }
    }
}