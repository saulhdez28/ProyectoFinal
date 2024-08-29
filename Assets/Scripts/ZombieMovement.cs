using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField]
    private float patrolSpeed = 2f;

    [SerializeField]
    private Transform[] patrolPoints;

    [SerializeField]
    private float waitTime = 2f;

    [Header("Chase Settings")]
    [SerializeField]
    private float chaseSpeed = 5f;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float chaseRange = 10f;

    //50%
    [SerializeField]
    private float attackProbability = 0.5f;


    private int currentPatrolIndex;
    private NavMeshAgent agent;
    private bool isWaiting;
    private bool isReturning;
    private ZombieAttackController attackController;
    private BulletEnemyAttackController bulletEnemyAttackController;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        attackController = GetComponent<ZombieAttackController>();
        bulletEnemyAttackController = GetComponent<BulletEnemyAttackController>();
        agent.speed = patrolSpeed;
        isReturning = false;
        GoToNextPatrolPoint();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < attackController.AttackRange)
        {
            agent.SetDestination(transform.position);
            animator.SetBool("isAttacking", true);

            // Generar un número aleatorio entre -1 y 1
            float randomValue = UnityEngine.Random.Range(-1f, 1f);

            if (randomValue < attackProbability)
            {
                attackController.Attack(player.GetComponent<PlayerHealthController>());
            }
            else if (randomValue > attackProbability && bulletEnemyAttackController != null) 
            {
                bulletEnemyAttackController.AttackBullet();
            }
            ResetAttackProbability();
        }

        else if (distanceToPlayer < chaseRange)
        {
            StopCoroutine(WaitAtPoint());
            ChasePlayer();
            animator.SetBool("isRunning", true);
        }
        else
        {
            Patrol();
        }

        if (!agent.hasPath && !isWaiting)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", true);
        }
    }

    void Patrol()
    {
        if (!isWaiting && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    private void ResetAttackProbability()
    {
        attackProbability = Random.Range(-1f, 1f); 
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        animator.SetBool("isIdle", false);
        animator.SetBool("isWalking", true);

        agent.destination = patrolPoints[currentPatrolIndex].position;

        if (!isReturning)
        {
            currentPatrolIndex++;
            if (currentPatrolIndex >= patrolPoints.Length)
            {
                isReturning = true;
                currentPatrolIndex = patrolPoints.Length - 2;
            }
        }
        else
        {
            currentPatrolIndex--;
            if (currentPatrolIndex < 0)
            {
                isReturning = false;
                currentPatrolIndex = 1;
            }
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", true);

        yield return new WaitForSeconds(waitTime);

        isWaiting = false;
        GoToNextPatrolPoint();
    }

    void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
        animator.SetBool("isRunning", true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
