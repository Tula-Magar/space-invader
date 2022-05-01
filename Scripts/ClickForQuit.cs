using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickForQuit : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; // exit the game in the editor mode
    }

    public void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 187, 255);
    }
    public void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(248, 248, 248, 255);
    }
}
