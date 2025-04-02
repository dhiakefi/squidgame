using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public Transform spawnArea;
    public int npcCount = 10;
    public float minSpawnDistance = 2.5f; // Minimum distance between NPCs

    private List<Vector3> spawnedPositions = new List<Vector3>(); // Store spawned NPC positions

    void Start()
    {
        for (int i = 0; i < npcCount; i++)
        {
            Vector3 spawnPosition = GetValidNavMeshPosition();
            GameObject npc = Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
            spawnedPositions.Add(spawnPosition); // Save position to check against future spawns
        }
    }

    Vector3 GetValidNavMeshPosition()
    {
        Vector3 randomPosition;
        NavMeshHit hit;
        int maxAttempts = 100;
        int attempts = 0;

        do
        {
            randomPosition = spawnArea.position + new Vector3(
                Random.Range(-20, 20),
                0,
                Random.Range(-20, 20)
            );

            attempts++;
        }
        while (!NavMesh.SamplePosition(randomPosition, out hit, 5f, NavMesh.AllAreas) ||
               IsTooCloseToOthers(hit.position) && attempts < maxAttempts);

        Debug.Log("NPC Spawned at: " + hit.position); // Debugging

        return hit.position;
    }


    bool IsTooCloseToOthers(Vector3 position)
    {
        foreach (Vector3 existingPos in spawnedPositions)
        {
            if (Vector3.Distance(position, existingPos) < minSpawnDistance)
            {
                return true; // Position is too close to another NPC
            }
        }
        return false;
    }
}
