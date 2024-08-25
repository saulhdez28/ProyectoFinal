using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float chaseSpeed = 5f;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Transform player;
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float waitTime = 2f; // Tiempo de espera en cada punto

    private int currentPatrolIndex;
    private NavMeshAgent agent;
    private bool isWaiting;
    private bool isReturning;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
        isReturning = false;
        GoToNextPatrolPoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < chaseRange)
        {
            StopCoroutine(WaitAtPoint());
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (!isWaiting && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        agent.destination = patrolPoints[currentPatrolIndex].position;

        if (!isReturning)
        {
            currentPatrolIndex++;
            if (currentPatrolIndex >= patrolPoints.Length)
            {
                isReturning = true;
                currentPatrolIndex = patrolPoints.Length - 2; // Retrocede al penúltimo punto
            }
        }
        else
        {
            currentPatrolIndex--;
            if (currentPatrolIndex < 0)
            {
                isReturning = false;
                currentPatrolIndex = 1; // Avanza al segundo punto
            }
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        GoToNextPatrolPoint();
    }

    void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar el rango de detección del zombie
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
