using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Range(5, 100)] float spawnRange;
    [SerializeField, Range(1, 20)] float spawnSpeed;
    [SerializeField, Range(5, 100)] int maxSpawnNumber;
    [SerializeField] Enemy prefab;

    float spawnTimer;

    List<Enemy> spawnedEnemys = new List<Enemy>();

    private void Update()
    {
        if (spawnTimer > 0)
            spawnTimer -= Time.deltaTime;
        if (spawnedEnemys.Count >= maxSpawnNumber) return;
        if (spawnTimer > 0) return;

        spawnTimer = 1 / spawnSpeed;

        var enemy = Instantiate(prefab.gameObject);
        var randomRange = Random.insideUnitCircle * spawnRange;
        enemy.transform.position = new Vector3(randomRange.x, 1, randomRange.y);
    }
}
