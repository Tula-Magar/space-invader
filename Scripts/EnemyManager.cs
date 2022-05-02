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

    private float TimerIncrease = 3.0f;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        timerShoot += Time.deltaTime;
        
        if (enemies.Count == 0) {
            timerRespawn += Time.deltaTime;  
            if (timerRespawn > TimerIncrease) {
                spawnManager.SpawnWave();
                TimerIncrease -= 0.5f; // We can slow down using different number, as for a level up test we gonna use 2.8f
                timerRespawn = 0;
            }
        }

        if (timerShoot > TimerIncrease && enemies.Count > 0) {
            int randomEnemy = Random.Range(0, enemies.Count);
            Instantiate(projectile, enemies[randomEnemy].transform.position, projectile.transform.rotation);
            timerShoot = 0;
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
