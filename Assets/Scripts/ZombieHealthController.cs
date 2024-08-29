using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthController : MonoBehaviour
{
    [SerializeField] 
    private float maxHealth = 100;
    
    private float currentHealth;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public float GetHealth(float value, bool percentage, float factor)
    {
        if (percentage)
        {
            return (maxHealth * Mathf.Abs(value) / 100.0F) * factor;
        }
        else
        {
            return Mathf.Abs(value) * factor;
        }
    }

    public void DecreaseHealth(float value, bool percentage = false)
    {
        animator.SetBool("isDamaged", true);
        currentHealth += GetHealth(value, percentage, -1);
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    public void IncreaseHealth(float value, bool percentage = false)
    {
        currentHealth += GetHealth(value, percentage, 1);
        if (currentHealth > 100.0f)
        {
            currentHealth = 100.0f;
        }
    }


    private void Die()
    {
        // Aquí va la animación de muerte
        animator.SetTrigger("Die");
        StateManager.Instance.setEnemiesDestroyed();
        Destroy(gameObject);
    }
}

