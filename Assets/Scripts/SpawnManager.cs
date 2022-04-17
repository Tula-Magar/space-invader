using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject alien;
    private float enemyCounter;

    void Start()
    {
        enemyCounter = 0;
        SpawnWave();
    }

    void Update()
    {
        
    }

    private void SpawnWave()
    {
        for (int i = 0; i < 45; i++) {
            Instantiate(alien, GenerateSpawnPosition(), alien.transform.rotation);
            enemyCounter++;
        }
    }

    private Vector2 GenerateSpawnPosition()
    {
        float x = -4.0f + (enemyCounter % 9);
        float y = 4.0f - Mathf.Floor(enemyCounter / 9);
        Vector2 spawnPosition = new Vector2(x, y);

        return spawnPosition;
    }
}
