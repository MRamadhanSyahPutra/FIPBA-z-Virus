using UnityEngine;

public class SpawnPointSet : MonoBehaviour
{
    // Array of spawn points for the main character
    [SerializeField] private Transform[] spawnPoints;
    // Reference to the main character (assign your "mc" in the Inspector)
    [SerializeField] private GameObject mainCharacter;

    void Start()
    {
        MoveCharacterToSpawnPoint();
    }

    // Method to move the existing main character to a random spawn point
    public void MoveCharacterToSpawnPoint()
    {
        if (spawnPoints.Length == 0 || mainCharacter == null)
        {
            Debug.LogError("Spawn points or main character not assigned.");
            return;
        }

        // Choose a random spawn point
        Transform chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Move the main character to the chosen spawn point
        mainCharacter.transform.position = chosenSpawnPoint.position;
        mainCharacter.transform.rotation = chosenSpawnPoint.rotation;
    }

    // Optional: Move character to a spawn point again (for respawning)
    public void RespawnCharacter()
    {
        MoveCharacterToSpawnPoint();
    }
}
