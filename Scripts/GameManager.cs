using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    private int score;
    private bool resetGame;
    private float timerReset;

    void Start()
    {
        resetGame = false;
        timerReset = 0;
    }

    void Update()
    {
        if (resetGame) { timerReset += Time.deltaTime; }
        if (timerReset >= 3.0f) { SceneManager.LoadScene("Menu"); }
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

    public void GameOver()
    {
        resetGame = true;
    }

    public int ScoreNum {
        get { return score;}
        set {this.score = this.score + value;}
    }
}
