using PlayerInputsAssetsController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3;

    private PlayerController playerController;

    private void Start()
    {
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
   
        if (collision != null)
        {
            ZombieHealthController healthController = collision.gameObject.GetComponent<ZombieHealthController>();

            if (healthController != null)
            {
                healthController.DecreaseHealth(playerController.syrengeDamage);
            }
        }
        
        Destroy(gameObject);
    }
}
