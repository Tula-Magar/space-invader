using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject alien;
    public GameObject alienShip;

    private float enemyCounter;
    private float timerAlienShip;

    void Start()
    {
        enemyCounter = 0;
        if (SceneManager.GetActiveScene().name == "PlayGame") { SpawnWave(); }
        // Debug for UnitTesting scene (excluded from executable build)
    }

    void Update()
    {
        // spawns a bonus ship every 10 seconds
        timerAlienShip += Time.deltaTime;
        if (timerAlienShip > 10.0f) {
            SpawnAlienShip();
            timerAlienShip = 0;
        }
    }

    // spawns 45 enemies, positioning is handled by another method
    public void SpawnWave()
    {
        for (int i = 0; i < 45; i++) {
            Instantiate(alien, GenerateSpawnPosition(), alien.transform.rotation);
            enemyCounter++;
        }
        enemyCounter = 0;
    }

    // randomizes bonus ship's spawn to left or right of screen
    private void SpawnAlienShip()
    {
        int xPosition;
        if (Random.Range(0, 2) == 1) { xPosition = 10; }
        else { xPosition = -10; }
        Instantiate(alienShip, new Vector2(xPosition, 5), alienShip.transform.rotation);
    }

    // modulus 9 used to loop x location, Mathf.Floor used to check for next row
    // position is returned to SpawnWave()
    private Vector2 GenerateSpawnPosition()
    {
        float x = -4.0f + (enemyCounter % 9);
        float y = 4.0f - Mathf.Floor(enemyCounter / 9);
        Vector2 spawnPosition = new Vector2(x, y);

        return spawnPosition;
    }
}
