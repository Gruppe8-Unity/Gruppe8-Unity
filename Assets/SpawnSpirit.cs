using System.Collections;
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

    void Start()
    {
        CreateSpirits();
    }

    void Update()
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

    void CreateSpirits()
    {
        for (int i = 0; i < numberOfSpirits; i++)
        {
            float angle = i * 360f / numberOfSpirits;
            Vector3 position = playerTransform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * orbitRadius;
            GameObject newSpirit = Instantiate(spiritPrefab, position, Quaternion.identity);
            spirits.Add(newSpirit);
        }
    }
}
