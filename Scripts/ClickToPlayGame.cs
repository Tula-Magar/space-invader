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
}
