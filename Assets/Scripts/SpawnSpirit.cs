using System.Collections.Generic;
using UnityEngine;

public class SpawnSpirit : MonoBehaviour
{
    public GameObject spiritPrefab;
    public Transform playerTransform; // Assign your character's transform in the Inspector
    public float orbitRadius = 2f; // Radius of the orbit circle
    public float orbitSpeed = 20f; // Speed of rotation around the player
    public int numberOfSpirits = 5; // Number of spirits to spawn
    private List<GameObject> spirits = new List<GameObject>(); // List to store spawned spirits
    public float timeUntilSpawn = 10;
    public float timeUntilDespawn = 5;
    public bool isSpawned = false;

    void Update()
    {
        if (isSpawned)
        {
            if (timeUntilDespawn <= 0)
            {
                DeleteSpirits();
            }
            for (int i = 0; i < spirits.Count; i++)
            {
                if (spirits[i] != null)
                {
                    float angle = (Time.time * orbitSpeed) + (i * 360f / numberOfSpirits);
                    Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * orbitRadius;
                    spirits[i].transform.position = playerTransform.position + offset;
                }
            }
            timeUntilDespawn -= Time.deltaTime;
        }
        else
        {
            if (timeUntilSpawn <= 0)
            {
                CreateSpirits();

            }
            timeUntilSpawn -= Time.deltaTime;
        }
    }
    void CreateSpirits()
    {
        isSpawned = true;
        timeUntilDespawn = 5;
        for (int i = 0; i < numberOfSpirits; i++)
        {
            float angle = i * 360f / numberOfSpirits;
            Vector3 position = playerTransform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * orbitRadius;
            GameObject newSpirit = Instantiate(spiritPrefab, position, Quaternion.identity);
            spirits.Add(newSpirit);
        }
    }
    void DeleteSpirits()
    {
        isSpawned = false;
        timeUntilSpawn = 10;
        foreach (GameObject spirit in spirits)
        {
            Destroy(spirit);
        }
    }
}
