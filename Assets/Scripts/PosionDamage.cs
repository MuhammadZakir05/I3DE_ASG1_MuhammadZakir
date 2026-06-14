/*
* Author: Muhammad Zakir
* Date: 14/05/2026
* Description:
*/

using UnityEngine;

/// <summary>
/// posion damage for the spill
/// </summary>
public class PoisonDamage : MonoBehaviour
{
    public float damageAmount = 1f;
    public float damageInterval = 0.2f;

    public AudioSource audioSource;
    public AudioClip hurtSound;

    private float damageTimer = 0f;

    /// <summary>
    /// Damage/few ms
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                PlayerHealth health = other.GetComponent<PlayerHealth>();

                if (health != null)
                {
                    health.TakeDamage(damageAmount);

                    // Play audio when damage taken
                    if (audioSource != null && hurtSound != null)
                    {
                        audioSource.PlayOneShot(hurtSound);
                    }
                }

                damageTimer = 0f;
            }
        }
    }

    /// <summary>
    /// Resets damage timer when not in touch
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageTimer = 0f;
        }
    }
}