using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Points")]
    public List<Transform> spawnPoints = new List<Transform>();

    [Header("Enemy Prefabs")]
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    [Header("Spawn Settings")]
    public float respawnCooldown = 5f;

    private GameObject currentEnemy;
    private bool isSpawning = false;

    private void Start()
    {
        // ให้ Factory รู้จัก Prefab
        EnemyFactory.Initialize(enemyPrefabs);

        SpawnEnemy();
    }

    private void OnEnable()
    {
        // Subscribe Event จาก EnemyHealth
        EnemyHealth.OnEnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDied -= OnEnemyDied;
    }

    void OnEnemyDied(GameObject deadEnemy)
    {
        if (currentEnemy == deadEnemy && !isSpawning)
        {
            StartCoroutine(RespawnTimer());
        }
    }

    IEnumerator RespawnTimer()
    {
        isSpawning = true;
        yield return new WaitForSeconds(respawnCooldown);
        SpawnEnemy();
        isSpawning = false;
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogError("❌ No spawn points!");
            return;
        }

        Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Count)];

        currentEnemy = EnemyFactory.CreateRandomEnemy(spawn.position, spawn.rotation);

        Debug.Log("✔ Spawned enemy via Factory at: " + spawn.name);
    }
}