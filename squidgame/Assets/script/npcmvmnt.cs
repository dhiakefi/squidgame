using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcmvmnt : MonoBehaviour
{
    public float speed; // This will be assigned by the spawner

    private NavMeshAgent agent;
    public Transform targetPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = speed;

            // Move forward toward a distant point
            //targetPosition = transform.position + transform.forward * 50f;
            agent.SetDestination(targetPosition.position);
        }
        else
        {
            Debug.LogError("NavMeshAgent component is missing on NPC.");
        }
    }

    void Update()
    {
        // Optional: Stop when reaching destination
       /* if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            // You can add logic here if needed (like playing idle animation)
        }*/
    }
}
