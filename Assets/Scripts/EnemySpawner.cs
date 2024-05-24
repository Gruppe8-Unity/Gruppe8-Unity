using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject basicEnemyPrefab;
    private float minimumSpawnTime = 1;
    private float maximumSpawnTime = 4;
    private float timeUntilSpawn;

    private void Awake()
    {
        SetTimeUntilSpawn();
    }
    private void Update()
    {
        DecrementCounter();
        SpawnEnemyOnCounterZero();
    }

    void SpawnEnemyOnCounterZero()
    {
        if (timeUntilSpawn <= 0)
        {
            Instantiate(basicEnemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    void DecrementCounter()
    {
        timeUntilSpawn -= Time.deltaTime;
    }
    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = UnityEngine.Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
