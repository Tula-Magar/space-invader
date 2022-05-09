using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

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
        InitialCallLike_Constructor();
    }

    void Update()
    {
        ScoreTxt.text = "Score: " + gameManager.ScoreNum;

        ReadFile();

        if (gameManager.ScoreNum > PlayerPrefs.GetInt("HighScoreAndReset", 0))
        {

            PlayerHighScore();
        }

        else if (PlayerPrefs.GetInt("highscore", 0) > Number)
        {

            WriteFile();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey(EventSystem.current.currentSelectedGameObject.name);
        HighScore.text = "Player highscore: 0";
    }

    public void ReadFile(){
        StreamReader reader = new StreamReader(path);
        Number = int.Parse(reader.ReadToEnd());
        reader.Close();
    }

    public void WriteFile(){
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(PlayerPrefs.GetInt("HighScoreAndReset", 0));
        writer.Close();
    }

    public void PlayerHighScore(){
        PlayerPrefs.SetInt("HighScoreAndReset", gameManager.ScoreNum);
        HighScore.text = "Player highscore: " + gameManager.ScoreNum.ToString();
    }

    public void InitialCallLike_Constructor(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ScoreTxt = GameObject.Find("Canvas/Score").GetComponent<Text>();
        HighScore = GameObject.Find("Canvas/HighScore").GetComponent<Text>();
        Resets = GameObject.Find("Canvas/HighScoreAndReset/Reset_button_name").GetComponent<Text>();
        GameObject.Find("Canvas/HighScoreAndReset").GetComponent<Image>().color = new Color(255, 0, 187, 255);

        Resets.text = "Reset";
        HighScore.text = "Player highscore: " + PlayerPrefs.GetInt("HighScoreAndReset").ToString();
        ScoreTxt.text = "Score: " + 0;
    }
}
