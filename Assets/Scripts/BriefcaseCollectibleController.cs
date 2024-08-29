using UnityEngine;
using UnityEngine.SceneManagement; 

public class BriefcaseCollectibleController : MonoBehaviour
{
    [SerializeField]
    private int briefcaseCountToLevelUp = 3; 

    private static int briefcasesCollected = 0; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            briefcasesCollected++;

            Debug.Log("Maletines recogidos: " + briefcasesCollected);
            StateManager.Instance.setCollectables();
            Destroy(gameObject); 

            if (briefcasesCollected >= briefcaseCountToLevelUp)
            {
                LoadLevel2(); 
            }
        }
    }

    private void LoadLevel2()
    {
        LevelManager.Instance.NextScene();
    }
}
