using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickForInfo : MonoBehaviour
{
    private GameObject playButton;
    public Sprite info;
    public Sprite back;
    private bool displayingInfo;

    public Text GameInfoText;

    private string Game_Info_Text = @"Enemy: shoots toward player randomly. The enemy will respawn as soon as all the enemies died

Player: Shoot using space keyboard, move left and right using left and right arrows keyboard

Player life span: 3, Game will be over after the player dies three times

Point score: 1 enemy killed is equal to 1 point and 1 alien ship killed is 3 point

Reset: Once the game is loaded and the player got moved then the reset button will be disable. You need to reset the personal computer high score at the beginning of the game or before player move player. ";

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
        if (!displayingInfo)
        {
            playButton.gameObject.SetActive(false);
            transform.position = new Vector2(transform.position.x, -4);
            GameInfoText.text = Game_Info_Text;
            this.GetComponent<SpriteRenderer>().sprite = back;
            displayingInfo = true;

            // disable game info screen
            GameObject.Find("Canvas/GlobalHighScore").GetComponent<Text>().enabled = false;
            GameObject.Find("Canvas/Greeting").GetComponent<Text>().enabled = false;
        }

        else
        {
            playButton.gameObject.SetActive(true);
            transform.position = new Vector2(transform.position.x, -1);
            this.GetComponent<SpriteRenderer>().sprite = info;
            displayingInfo = false;
            GameObject.Find("Canvas/GlobalHighScore").GetComponent<Text>().enabled = true;
            GameInfoText.text = "";
            GameObject.Find("Canvas/Greeting").GetComponent<Text>().enabled = true;
        }
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
