using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Slider healthSlider;
    public TextMeshProUGUI hpValueText;

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
            Debug.Log("Player died");
        }
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
        hpValueText.text = Mathf.CeilToInt(currentHealth) + "/" + Mathf.CeilToInt(maxHealth);
    }
}