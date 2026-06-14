using UnityEngine;

/// <summary>
/// Shows win screen upon escaping
/// </summary>
public class WinTrigger : MonoBehaviour
{
    public GameObject winPanel;
    public Inventory playerInventory;

    private void Start()
    {
        winPanel.SetActive(false);
    }

    /// <summary>
    /// Checks generator repaired
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerInventory.generatorRepaired)
        {
            winPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;

            Debug.Log("Player escaped");
        }
    }
}