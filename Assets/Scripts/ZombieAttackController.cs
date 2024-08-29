using UnityEngine;

public class ZombieAttackController : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField]
    private int attackDamage = 10; 

    [SerializeField]
    private float timeBetweenAttacks = 1.5f;

    [SerializeField]
    private float attackRange = 2f; 

    private bool hasAttacked;
    private float lastAttackTime;

    public float AttackRange => attackRange; 
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastAttackTime = -timeBetweenAttacks; 
    }

    public void Attack(PlayerHealthController playerHealth)
    {
        if (!hasAttacked && Time.time - lastAttackTime >= timeBetweenAttacks)
        {
            playerHealth.DecreaseHealth(attackDamage);
            hasAttacked = true;
            lastAttackTime = Time.time;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    void ResetAttack()
    {
        hasAttacked = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
