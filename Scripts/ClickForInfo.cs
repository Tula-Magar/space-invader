using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickForInfo : MonoBehaviour
{
    private GameObject playButton;
    public Sprite info;
    public Sprite back;
    public Text GameInfoText;

    private bool displayingInfo;
    private string Game_Info_Text = @"Enemy: Enemies spawn in waves and shoot at the player. Defeat them all to advance to the next wave.

Player: Press SPACE to shoot, use left/right arrows or A and D to move. Players have 3 lives.

Scoring: Each enemy is worth one point. Bonus ships are worth 3 points.

Reset: Resets the local high score.";

    void Start()
    {
        playButton = GameObject.Find("PlayButton");
        displayingInfo = false;
    }

    void Update()
    {

    }

    // rotates between what is displayed to user
    void OnMouseDown()
    {
        if (!displayingInfo)
        {
            NotDisplaying();
        }

        else
        {
           Displaying();
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

    public void NotDisplaying(){

        playButton.gameObject.SetActive(false);
        transform.position = new Vector2(transform.position.x, -4);
        GameInfoText.text = Game_Info_Text;
        this.GetComponent<SpriteRenderer>().sprite = back;
        displayingInfo = true;

        // disable game info screen
        GameObject.Find("Canvas/GlobalHighScore").GetComponent<Text>().enabled = false;
        GameObject.Find("Canvas/Greeting").GetComponent<Text>().enabled = false;
    }

    public void Displaying(){

        playButton.gameObject.SetActive(true);
        transform.position = new Vector2(transform.position.x, -1);
        this.GetComponent<SpriteRenderer>().sprite = info;
        displayingInfo = false;
        GameObject.Find("Canvas/GlobalHighScore").GetComponent<Text>().enabled = true;
        GameInfoText.text = "";
        GameObject.Find("Canvas/Greeting").GetComponent<Text>().enabled = true;

    }
}
