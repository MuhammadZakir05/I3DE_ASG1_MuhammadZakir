using UnityEngine;
using TMPro;

public class FusePickup : MonoBehaviour
{
    public TextMeshProUGUI interactText;

    private bool playerInRange = false;
    private Inventory playerInventory;

    void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerInventory.AddFuse();
            interactText.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactText.gameObject.SetActive(false);
        }
    }
}