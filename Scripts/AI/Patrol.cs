 using UnityEngine;
using UnityEngine.AI;

// Controls enemy patrol behavior and player chasing using NavMesh navigation.

public class Patrol : MonoBehaviour
{
    // Patrol points array
    public Transform[] patrolPoints;

    // Current target patrol point
    [SerializeField] private int targetPoint;

    // NavMeshAgent for movement
    public NavMeshAgent mask;

    public float chaseRange = 10f;
    public GameObject player;

    void Start()
    {
        targetPoint = 0;
        
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < chaseRange)
        {
            Chase();
        }
        else
        {
            PatrolArea();
        }
    }

    public void PatrolArea()
    {
        // Set patrol speed and angular speed
        mask.speed = 6f;
        mask.angularSpeed = 120;
        mask.SetDestination(patrolPoints[targetPoint].position);

        // Check if agent reached current patrol point
        if (!mask.pathPending && mask.remainingDistance < 0.4f)
        {
            IncreaseTarget();
        } 
    }
    public void IncreaseTarget()
    {
        targetPoint++;

        if(targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

    public void Chase()
    {
        // Set chase speed and angular speed
        mask.speed = 12f;
        mask.angularSpeed = 400;
        mask.SetDestination(player.transform.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerRespawn>(out var player))
        {
            // Kill player on collision
            player.Die();

        }
    }
}

