using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Score : MonoBehaviour
{
    private GameManager gameManager;
    private Text ScoreTxt;
    private Text HighScore;
    private Text Resets;
    private int Number;
    private string path = "Assets/Resources/GlobalHighScore.txt";

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ScoreTxt = GameObject.Find("Canvas/Score").GetComponent<Text>();
        HighScore = GameObject.Find("Canvas/HighScore").GetComponent<Text>();
        Resets = GameObject.Find("Canvas/Reset_button/Reset_button_name").GetComponent<Text>();
        GameObject.Find("Canvas/Reset_button").GetComponent<Image>().color = new Color(255, 0, 187, 255);

        Resets.text = "Reset";
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("highscore").ToString();
        ScoreTxt.text = "Score: " + 0;

    }

    void Update()
    {
        ScoreTxt.text = "Score: " + gameManager.ScoreNum;

        StreamReader reader = new StreamReader(path);
        Number = int.Parse(reader.ReadToEnd());
        reader.Close();

        if (gameManager.ScoreNum > PlayerPrefs.GetInt("highscore", 0))
        {

            PlayerPrefs.SetInt("highscore", gameManager.ScoreNum);
            HighScore.text = "High Score: " + gameManager.ScoreNum.ToString();
        }

        else if (PlayerPrefs.GetInt("highscore", 0) > Number)
        {

            StreamWriter writer = new StreamWriter(path, false);
            writer.Write(PlayerPrefs.GetInt("highscore", 0));
            writer.Close();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        HighScore.text = "High Score: 0";
    }



}
