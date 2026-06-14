/*
* Author: Muhammad Zakir
* Date: 14/05/2026
* Description:
*/

/// <summary>
/// Manage inventory progress
/// generator repair status, and updates the objective UI.
/// </summary>

using UnityEngine;
using TMPro;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public int fuseCount = 0;
    public int maxFuses = 5;

    public bool hasKeycard = false;
    public bool generatorRepaired = false;

    public TextMeshProUGUI FuseCollected;
    public GameObject CongratsPanel;

    void Start()
    {
        CongratsPanel.SetActive(false);
        UpdateUI();
    }

    /// <summary>
    /// +1 fuse and update objective
    /// </summary>
    public void AddFuse()
    {
        fuseCount++;

        // Prevent fuse count from exceeding the amt.
        if (fuseCount > maxFuses)
        {
            fuseCount = maxFuses;
        }

        UpdateUI();

        // congrats message if max fuse collected (5)
        if (fuseCount >= maxFuses)
        {
            CongratsPanel.SetActive(true);
            StartCoroutine(HideCongratsPanel());
        }
    }

    /// <summary>
    /// Collected keycard
    /// </summary>
    public void AddKeycard()
    {
        hasKeycard = true;
        UpdateUI();

        Debug.Log("Keycard obtained");
    }

    /// <summary>
    /// repaired generator
    /// </summary>
    public void RepairGenerator()
    {
        generatorRepaired = true;
        UpdateUI();

        Debug.Log("Generator repaired");
    }

    /// <summary>
    /// Updates top right UI's progress
    /// </summary>
    public void UpdateUI()
    {
        string keycardStatus = hasKeycard ? "Found" : "Not Found";
        string generatorStatus = generatorRepaired ? "Repaired" : "Not Repaired";
        string roomStatus = hasKeycard && generatorRepaired ? "Unlocked" : "Locked";

        FuseCollected.text =
            "OBJECTIVES\n\n" +
            "Fuses: " + fuseCount + "/" + maxFuses + "\n" +
            "Keycard: " + keycardStatus + "\n" +
            "Generator: " + generatorStatus + "\n" +
            "Experiment Room: " + roomStatus;
    }

    /// <summary>
    /// Hide congrats panel after 3 seconds
    /// </summary>
    private IEnumerator HideCongratsPanel()
    {
        yield return new WaitForSeconds(3f);
        CongratsPanel.SetActive(false);
    }
}