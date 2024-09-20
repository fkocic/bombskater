using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTimer : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [SerializeField] float spawnTime = 2;
    [SerializeField] float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnTime;
    }

    private void Update()
    {
        if (spawnTimer < 0)
        {
            SpawnEnemy();

        }
    }

    private void SpawnEnemy()
    {

    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private GameObject ChooseEnemyToSpawn()
    {
        int chance = Random.Range(0, 100);

        if (chance < 33)
        {
            return enemies[0];
        }
        if (chance >= 33 && chance < 67)
        {
            return enemies[1];
        }
        else
        {
            return enemies[2];
        }
    }
}
