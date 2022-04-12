using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        
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