using UnityEngine;

public class ZombieAttackController : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField]
    private int attackDamage = 10;

    [SerializeField]
    private float timeBetweenAttacks = 1.5f;

    [SerializeField]
    private float attackRange = 2f; // Rango de ataque melee

    private bool hasAttacked;
    private float lastAttackTime;

    public float AttackRange => attackRange; // Propiedad para acceder al rango de ataque desde ZombieMovement

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastAttackTime = -timeBetweenAttacks; // Para que pueda atacar inmediatamente si está en rango
    }

    public void Attack(PlayerHealthController playerHealth)
    {
        if (!hasAttacked && Time.time - lastAttackTime >= timeBetweenAttacks)
        {
            animator.SetBool("isAttacking", true);
            playerHealth.TakeDamage(attackDamage);
            hasAttacked = true;
            lastAttackTime = Time.time;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        hasAttacked = false;
        animator.SetBool("isAttacking", false);
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar el rango de ataque del zombie (aparece un circulo para simular el rango)
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
