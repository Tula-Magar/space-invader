using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private int score;
    private int playerLives;
    private bool newLife;
    private bool resetGame;
    private float timerReset;

    void Start()
    {
        Instantiate(player, new Vector2(0, -4), player.transform.rotation);

        playerLives = 3;
        resetGame = false;
        timerReset = 0;
    }

    void Update()
    {
        if (resetGame || newLife) { timerReset += Time.deltaTime; }
        if (timerReset >= 3.0f) {
            if (newLife) {
                Instantiate(player, new Vector2(0, -4), player.transform.rotation);
                newLife = false;
            } else { SceneManager.LoadScene("Menu"); }

            timerReset = 0;
        }
    }

    public void PlayerDied()
    {
        playerLives = playerLives - 1;
        if (playerLives > 0) { newLife = true; }
        else { resetGame = true; }
        
    }

    public int ScoreNum {
        get { return score;}
        set {this.score = this.score + value;}
    }
}
