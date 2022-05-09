using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GlobalHighScore : MonoBehaviour
{
    private string path = "Assets/Resources/GlobalHighScore.txt"; // Assets/Resources/GlobalHighScore.txt
    private Text globalHighScore;

    private Text Greeting;
    void Start()
    {
        globalHighScore = GameObject.Find("Canvas/GlobalHighScore").GetComponent<Text>();
        Greeting = GameObject.Find("Canvas/Greeting").GetComponent<Text>();
        Greeting.text = "Hi, welcome to space-invader game!!";

        ReadFile();

    }

    void Update()
    {

    }

     // Read the file of global high score 
    public void ReadFile(){
        StreamReader reader = new StreamReader(path);
        globalHighScore.text = "Global High Score: " + reader.ReadToEnd();
        reader.Close();
    }
}
