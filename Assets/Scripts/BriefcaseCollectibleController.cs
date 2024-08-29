using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class BriefcaseCollectibleController : MonoBehaviour
{
    [SerializeField]
    private int briefcaseCountToLevelUp = 3; // N�mero de maletines necesarios para cambiar de escena

    private static int briefcasesCollected = 0; // Contador est�tico para mantener la cuenta a trav�s de m�ltiples instancias

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            briefcasesCollected++;

            Debug.Log("Maletines recogidos: " + briefcasesCollected);

            Destroy(gameObject); // Destruye el malet�n una vez recogido

            if (briefcasesCollected >= briefcaseCountToLevelUp)
            {
                LoadLevel2(); // Cambia a la escena de Level 2
            }
        }
    }

    private void LoadLevel2()
    {
        // Aseg�rate de que la escena "Level 2" est� incluida en las configuraciones de construcci�n (Build Settings)
        SceneManager.LoadScene("Level2");
    }
}
