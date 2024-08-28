using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]
    private int healthIncrease = 20; // Incremento de 20 puntos de salud (2 corazones)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController playerHealth = other.GetComponent<PlayerHealthController>();
            if (playerHealth != null)
            {
                // Verificar si el jugador tiene menos de la salud máxima (por ejemplo, menos de 5 corazones)
                if (playerHealth.CurrentHealth < playerHealth.MaxHealth)
                {
                    playerHealth.IncreaseHealth(healthIncrease);
                    Destroy(gameObject); // Destruye el objeto coleccionable para simular que ha sido recogido
                }
                else
                {
                    Debug.Log("Salud completa. No se puede recoger el coleccionable.");
                }
            }
        }
    }
}
