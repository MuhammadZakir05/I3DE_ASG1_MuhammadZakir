/*
* Author: Muhammad Zakir
* Date: 14/05/2026
* Description:
*/

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages player health, HP UI, game over, and restarting the scene.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Slider healthSlider;
    public TextMeshProUGUI hpValueText;

    public GameObject gameOverPanel;

    void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        UpdateHealthUI();
    }

    /// <summary>
    /// Damages player health and checks death
    /// </summary>
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Prevent health from going below 0.
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Updates health slider and HP text.
    /// </summary>
    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
        hpValueText.text = Mathf.CeilToInt(currentHealth) + "/" + Mathf.CeilToInt(maxHealth);
    }

    /// <summary>
    /// GameOver screen
    /// </summary>
    void Die()
    {
        gameOverPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    /// <summary>
    /// Restarts.
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}