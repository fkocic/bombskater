using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject tileVisualPrefab;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] float respawnTime = 10;

    public bool isDestroyed = false;
    public bool isOccupied = false;

    private float respawnTimer;
    private Vector3 bombSpawnCoordinates;

    private void Start()
    {
        bombSpawnCoordinates = transform.position + new Vector3(0, 0.4f, 0);
        respawnTimer = respawnTime;
    }

    void Update()
    {
        if (isDestroyed)
        {
            respawnTimer -= Time.deltaTime;
            
            if (respawnTimer <= 0)
            {
                RespawnTile();
            }
        }
            
    }

    private void RespawnTile()
    {
        tilePrefab.SetActive(true);
        tileVisualPrefab.SetActive(true);
        respawnTimer = respawnTime;
        isDestroyed = false;
        AudioManager.Instance.PlayPop();
    }

    public void SpawnBomb()
    {
        if (isOccupied) return;
        Instantiate(bombPrefab, bombSpawnCoordinates, Quaternion.identity, transform);
        isOccupied = true;
    }

    public void DestroyTile()
    {
        tilePrefab.SetActive(false);
        tileVisualPrefab.SetActive(false);
        isOccupied = false;
        isDestroyed = true;
    }
}
