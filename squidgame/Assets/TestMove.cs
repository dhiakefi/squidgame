using UnityEngine;
using UnityEngine.AI;

public class TestMove : MonoBehaviour
{
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.SetDestination(new Vector3(0, 0, 10)); // Moves forward
        }
        else
        {
            Debug.LogError("NavMeshAgent not found!");
        }
    }
}
