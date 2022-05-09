using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private List<GameObject> enemies = new List<GameObject>();
    public GameObject projectile;

    private float timerShoot;
    private float timerRespawn;
    private float shootCooldown = 3.0f;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        timerShoot += Time.deltaTime;
        
        // respawns wave of enemies if none in list
        if (enemies.Count == 0) {
            timerRespawn += Time.deltaTime;  // transition timer
            if (timerRespawn > 3.0f) {
                spawnManager.SpawnWave();
                if (shootCooldown >= 1.0f) { shootCooldown -= 0.5f; } // prevents negative timers
                timerRespawn = 0;
            }
        }

        if (timerShoot > shootCooldown && enemies.Count > 0) {  // prevents out-of-bounds errors if no enemies in list
            int randomEnemy = Random.Range(0, enemies.Count);
            Instantiate(projectile, enemies[randomEnemy].transform.position, projectile.transform.rotation);
            timerShoot = 0;     // randomly selects enemy and spawns projectile at position
        }
    }

    // modified Observer pattern
    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    public void EnemiesChangeDirection()
    {
        foreach(GameObject enemy in enemies) {
            enemy.GetComponent<EnemyMovement>().ChangeDirection();
        }
    }
}
