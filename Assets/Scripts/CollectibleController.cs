using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]
    // Incremento de 20 puntos de salud (2 corazones)
    private int healthIncrease = 20; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController playerHealth = other.GetComponent<PlayerHealthController>();
            if (playerHealth != null)
            {
                // Verificar si el jugador tiene menos de la salud máxima
                //(5 corazones)
                if (playerHealth.CurrentHealth < playerHealth.MaxHealth)
                {
                    playerHealth.IncreaseHealth(healthIncrease);
                    // Destruye el objeto coleccionable para simular que ha sido recogido
                    Destroy(gameObject); 
                }
                else
                {
                    Debug.Log("Salud completa. No se puede recoger el coleccionable.");
                }
            }
        }
    }
}
