using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int fuseCount = 0;
    public int maxFuses = 5;

    public TextMeshProUGUI FuseCollected;

    void Start()
    {
        UpdateUI();
    }

    public void AddFuse()
    {
        fuseCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        FuseCollected.text = "Fuses: " + fuseCount + "/" + maxFuses;
    }
}