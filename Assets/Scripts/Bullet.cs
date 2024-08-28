using PlayerInputsAssetsController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3;

    private GameObject[] enemyControllers;

    private PlayerController playerController;

    private void Start()
    {
        enemyControllers = GameObject.FindGameObjectsWithTag("Enemy");
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }
    }

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject obj in enemyControllers)
        {
            if (obj != null)
            {
                ZombieHealthController healthController = obj.GetComponent<ZombieHealthController>();

                if (healthController != null)
                {
                    healthController.DecreaseHealth(playerController.syrengeDamage);
                }
            }
        }
        Destroy(gameObject);
    }
}
