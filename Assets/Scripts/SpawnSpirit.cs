using System.Collections.Generic;
using UnityEngine;

public class SpawnSpirit : MonoBehaviour
{
    public GameObject spiritPrefab;
    public Transform playerTransform; 
    public float orbitRadius = 2f; 
    public float orbitSpeed = 20f; 
    public int numberOfSpirits = 5; 
    private List<GameObject> spirits = new List<GameObject>(); 
    public float timeUntilSpawn = 10f;
    public float timeUntilDespawn = 5f;
    public bool isSpawned = false;

    void Update()
    {
        DetermineIfSpawnedOrDespawn();
    }

    void DetermineIfSpawnedOrDespawn()
    {
        if (isSpawned)
        {
            DetermineSpiritDespawn();
            RotateSpiritsAroundPlayer();
            DecrementSpiritTimerDespawn();
        }
        else
        {
            DetermineSpiritSpawn();
            DecrementSpiritTimerSpawn();
        }
    }

    void DetermineSpiritSpawn()
    {
        if (timeUntilSpawn <= 0f)
        {
            CreateSpirits();

        }
    }
    void DecrementSpiritTimerSpawn()
    {
        timeUntilSpawn -= Time.deltaTime;
    }

    void DecrementSpiritTimerDespawn()
    {
        timeUntilDespawn -= Time.deltaTime;
    }

    void RotateSpiritsAroundPlayer()
    {
        for (int i = 0; i < spirits.Count; i++)
        {
            if (spirits[i] != null)
            {
                float angle = (Time.time * orbitSpeed) + (i * 360f / numberOfSpirits);
                Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * orbitRadius;
                spirits[i].transform.position = playerTransform.position + offset;
            }
        }
    }

    void DetermineSpiritDespawn()
    {
        if (timeUntilDespawn <= 0f)
        {
            DeleteSpirits();
        }
    }
    void CreateSpirits()
    {
        isSpawned = true;
        timeUntilDespawn = 5f;
        for (int i = 0; i < numberOfSpirits; i++)
        {
            float angle = i * 360f / numberOfSpirits;
            Vector3 position = playerTransform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * orbitRadius;
            GameObject newSpirit = Instantiate(spiritPrefab, position, Quaternion.identity);
            spirits.Add(newSpirit);
        }
        FindObjectOfType<AudioManager>().Play("SpiritSound");
    }
    void DeleteSpirits()
    {
        isSpawned = false;
        timeUntilSpawn = 10f;
        foreach (GameObject spirit in spirits)
        {
            Destroy(spirit);
        }
        FindObjectOfType<AudioManager>().Play("SpiritSound");

    }
}
