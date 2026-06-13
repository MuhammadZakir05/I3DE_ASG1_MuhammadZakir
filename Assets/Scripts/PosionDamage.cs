using UnityEngine;

public class PoisonDamage : MonoBehaviour
{
    public float damageAmount = 1f;
    public float damageInterval = 0.2f;

    public AudioSource audioSource;
    public AudioClip hurtSound;

    private float damageTimer = 0f;

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

                    if (hurtSound != null)
                    {
                        audioSource.PlayOneShot(hurtSound);
                    }
                }

                damageTimer = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageTimer = 0f;
        }
    }
}