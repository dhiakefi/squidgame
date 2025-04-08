using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;            // Prefab to spawn
    public Transform spawnArea;             // Start position for the grid
    public int npcCount = 30;               // Total NPCs to spawn
    public float spacing = 2f;              // Distance between NPCs in the grid

    public float minSpeed = 1.5f;           // Minimum NPC movement speed
    public float maxSpeed = 3.5f;           // Maximum NPC movement speed

    void Start()
    {
        int rowCount = Mathf.CeilToInt(Mathf.Sqrt(npcCount));
        int colCount = Mathf.CeilToInt((float)npcCount / rowCount);

        Vector3 startPos = spawnArea.position;

        int spawned = 0;
        for (int row = 0; row < rowCount && spawned < npcCount; row++)
        {
            for (int col = 0; col < colCount && spawned < npcCount; col++)
            {
                Vector3 spawnPos = startPos + new Vector3(col * spacing, 0, row * spacing);
                GameObject npc = Instantiate(npcPrefab, spawnPos, Quaternion.identity);

                // Set a random speed if NPCMovement script exists
                npcmvmnt npcMove = npc.GetComponent<npcmvmnt>();
                if (npcMove != null)
                {
                    npcMove.speed = Random.Range(minSpeed, maxSpeed);
                }

                spawned++;
            }
        }
    }
}
