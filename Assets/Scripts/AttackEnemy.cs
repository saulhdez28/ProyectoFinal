using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{

    public bool attacking = false;
    public LayerMask enemyLayer;
    public GameObject enemy;


    private void OnTriggerEnter(Collider collider)
    {
        if (((1 << collider.gameObject.layer) & enemyLayer) != 0)
        {

            ZombieHealthController enemyHealth = collider.GetComponent<ZombieHealthController>();
            if (enemyHealth != null)
            {
                enemy = collider.gameObject;
                attacking = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            ZombieHealthController enemyHealth = other.GetComponent<ZombieHealthController>();
            if (enemyHealth != null)
            {
                enemy = null;
                attacking = false;
            }
        }
    }
}
