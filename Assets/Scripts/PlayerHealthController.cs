using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth); // Imprimir la vida actual del jugador

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died."); // Imprimir mensaje de muerte
        Destroy(gameObject);
    }
}
