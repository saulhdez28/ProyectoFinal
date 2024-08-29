using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeated : MonoBehaviour
{
    [SerializeField]
    ZombieHealthController zombieHealthController;

    private void Update()
    {
        if (zombieHealthController.currentHealth <= 0.01f || zombieHealthController == null)
        {
            LevelManager.Instance.GameOver();
        }

    }
}
