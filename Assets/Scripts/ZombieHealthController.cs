using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthController : MonoBehaviour
{
    [SerializeField] 
    private int maxHealth = 100;
    
    private int currentHealth;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        animator.SetBool("isDamaged", true);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Aquí va la animación de muerte
        animator.SetTrigger("Die");

        Destroy(gameObject);
    }
}

