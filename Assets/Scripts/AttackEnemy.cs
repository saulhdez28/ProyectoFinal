using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{

    public bool attacking = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ZombieHealthController enemyHealth = other.GetComponent<ZombieHealthController>();
            if (enemyHealth != null)
            {
                attacking = true;              
            }
        }
    }
}
