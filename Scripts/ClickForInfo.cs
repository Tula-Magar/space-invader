using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForInfo : MonoBehaviour
{
    private GameObject playButton;
    public Sprite info;
    public Sprite back;

    private bool displayingInfo;

    void Start()
    {   
        playButton = GameObject.Find("PlayButton");
        displayingInfo = false;
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (!displayingInfo) {
            playButton.gameObject.SetActive(false);
            transform.position = new Vector2(transform.position.x, -4);
            this.GetComponent<SpriteRenderer>().sprite = back;
            displayingInfo = true;
        } else {
            playButton.gameObject.SetActive(true);
            transform.position = new Vector2(transform.position.x, -1);
            this.GetComponent<SpriteRenderer>().sprite = info;
            displayingInfo = false;
        }
    }
}
