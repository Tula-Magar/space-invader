using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameManager gameManager;

    public Text ScoreTxt;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ScoreTxt = GameObject.Find("Canvas/Text").GetComponent<Text>();
        ScoreTxt.text = "Score: " + 0;
    }

    void Update()
    {
        ScoreTxt.text = "Score: " + gameManager.ScoreNum;
    }

}
