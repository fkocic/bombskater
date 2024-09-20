using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject spawnParticle;
    [SerializeField] float particleSpawnTime = 5;
    [SerializeField] float enemySpawnTime = 2;

    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [SerializeField] List<GameObject> tiles = new List<GameObject>();

    private float enemySpawnTimer = 0;
    private int enemySpawnNumber = 1;

    public int difficultyLevel = 1;

    private void Start()
    {
        enemySpawnTimer = enemySpawnTime;
    }

    private void Update()
    {
        if (!LevelManager.Instance.isInCountdown)
        {
            if (enemySpawnTimer < 0)
            {
                for (int i = 0; i < enemySpawnNumber; i++)
                {
                    StartCoroutine(SpawnEnemy());
                }

                enemySpawnTimer = enemySpawnTime;
            }

            enemySpawnTimer -= Time.deltaTime;
        }      
    }
    

    IEnumerator SpawnEnemy()
    {
        int tileIndex = ReturnTileIndex();
        Vector3 spawnPostition = tiles[tileIndex].transform.position;
        GameObject particle = Instantiate(spawnParticle);
        particle.transform.position = spawnPostition;

        yield return new WaitForSeconds(enemySpawnTime);

        Destroy(particle);
        GameObject enemyToSpawn = ChooseEnemyToSpawn();
        spawnPostition = tiles[tileIndex].transform.position + 0.5f * Vector3.up;
        GameObject enemy = Instantiate(enemyToSpawn, spawnPostition, Quaternion.identity, transform);
        enemy.GetComponent<EnemyBehaviour>().SetTarget(player);
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

    private int ReturnTileIndex()
    {
        int index = Random.Range(0, tiles.Count);
        GameObject tile = tiles[index];

        if (tile.GetComponent<TileBehaviour>().isDestroyed)
        {
            return ReturnTileIndex();
        }
        else return index;
    }

    public void DecreaseParticleTime()
    {
        particleSpawnTime -= particleSpawnTime / 10;
    }

    public void IncreaseEnemySpawnNumber()
    {
        enemySpawnNumber++;
    }
}
