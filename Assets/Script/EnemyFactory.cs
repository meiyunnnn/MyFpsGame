using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private static List<GameObject> enemyPrefabs;

    public static void Initialize(List<GameObject> prefabs)
    {
        enemyPrefabs = prefabs;
    }

    public static GameObject CreateRandomEnemy(Vector3 pos, Quaternion rot)
    {
        if (enemyPrefabs == null || enemyPrefabs.Count == 0)
        {
            Debug.LogError("❌ EnemyFactory: Prefabs not assigned!");
            return null;
        }

        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        return Object.Instantiate(prefab, pos, rot);
    }
}