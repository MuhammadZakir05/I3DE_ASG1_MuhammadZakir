using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

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

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
        hpValueText.text = Mathf.CeilToInt(currentHealth) + "/" + Mathf.CeilToInt(maxHealth);
    }

    void Die()
{
    gameOverPanel.SetActive(true);

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    Time.timeScale = 0f;
}

public void RestartGame()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
}