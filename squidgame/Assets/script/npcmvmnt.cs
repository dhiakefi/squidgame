using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcmvmnt : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform finishLine;
    // Start is called before the first frame update
    void Start()
    {
    agent = GetComponent<NavMeshAgent>();
    agent.SetDestination(finishLine.position);

    }

// Update is called once per frame
void Update()
    {
    
}
}
