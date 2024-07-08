using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float yRange;
    [SerializeField] float xRange;

    [SerializeField] List<Enemy> enemies = new List<Enemy>();
    [SerializeField] int numberToSpawn;

    void Start()
    {
        PopulateEnemies(numberToSpawn);
    }

    void PopulateEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Count)].gameObject, new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange) , 0f), Quaternion.identity);
    }
}
