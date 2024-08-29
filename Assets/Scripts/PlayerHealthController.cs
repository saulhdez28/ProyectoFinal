using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;

    private float currentHealth;

    // Asigna en el inspector las im�genes de los corazones
    public Image[] hearts; // Los �conos de corazones
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Propiedades p�blicas para acceder a la salud actual y m�xima
    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public float CalculateHealth(float value, bool percentage, float factor)
    {
        float adjustment = percentage ? (maxHealth * Mathf.Abs(value) / 100.0f) * factor : Mathf.Abs(value) * factor;
        return adjustment;
    }

    public void DecreaseHealth(float value, bool percentage = false)
    {
        currentHealth -= CalculateHealth(value, percentage, 1);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI(); // Actualizar la UI de corazones

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    public void IncreaseHealth(float value, bool percentage = false)
    {
        currentHealth += CalculateHealth(value, percentage, 1);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI(); // Aseg�rate de que esta l�nea est� presente para actualizar la UI
    }


    private void UpdateHealthUI()
    {
        // Asumiendo que cada coraz�n representa 10 puntos de salud
        int healthPerHeart = (int)(maxHealth / hearts.Length);

        for (int i = 0; i < hearts.Length; i++)
        {
            if (currentHealth >= (i + 1) * healthPerHeart)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void Die()
    {
        if (gameObject != null)
        {
            Debug.Log("Player has died.");
            Destroy(gameObject);
            LevelManager.Instance.LastScene();
        }
    }
}
