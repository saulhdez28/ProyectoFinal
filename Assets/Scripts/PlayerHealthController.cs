using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetHealth(float value, bool percentage, float factor)
    {
        if (percentage)
        {
            return (maxHealth * Mathf.Abs(value) / 100.0F) * factor;
        }
        else
        {
            return Mathf.Abs(value) * factor;
        }
    }

    public void DecreaseHealth(float value, bool percentage = false)
    {
        currentHealth += GetHealth(value, percentage, -1);
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    public void IncreaseHealth(float value, bool percentage = false)
    {
        currentHealth += GetHealth(value, percentage, 1);
        if (currentHealth > 100.0f)
        {
            currentHealth = 100.0f;
        }
    }

    public void Die()
    {
        if (gameObject != null)
        {
            Debug.Log("Player has died.");
            Destroy(gameObject);
        }
    }
}
