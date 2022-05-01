using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToPlayGame : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("PlayGame");
    }

    void OnMouseOver()
    {
       GetComponent<SpriteRenderer>().color = new Color (255, 0, 187, 255);
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color (248, 248, 248, 255);
    }
}
