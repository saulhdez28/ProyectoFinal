using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class BriefcaseCollectibleController : MonoBehaviour
{
    [SerializeField]
    private int briefcaseCountToLevelUp = 3; // Número de maletines necesarios para cambiar de escena

    private static int briefcasesCollected = 0; // Contador estático para mantener la cuenta a través de múltiples instancias

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            briefcasesCollected++;

            Debug.Log("Maletines recogidos: " + briefcasesCollected);

            Destroy(gameObject); // Destruye el maletín una vez recogido

            if (briefcasesCollected >= briefcaseCountToLevelUp)
            {
                LoadLevel2(); // Cambia a la escena de Level 2
            }
        }
    }

    private void LoadLevel2()
    {
        // Asegúrate de que la escena "Level 2" esté incluida en las configuraciones de construcción (Build Settings)
        SceneManager.LoadScene("Level2");
    }
}
