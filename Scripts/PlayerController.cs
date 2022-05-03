using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject projectile;
    public GameObject Explosion;

    private float movementDirection;
    private float timerMove;
    private float timerShoot;
    private float xRange = 8.4f;
    private Text Player_Lives;
    private bool CallOnlyOneTime;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        CallOnlyOneTime = true;
        Player_Lives = GameObject.Find("Canvas/PlayerLives").GetComponent<Text>();
        Player_Lives.text = "PlayerLives: " + gameManager.Get_playerLives();
    }

    void Update()
    {
        timerMove += Time.deltaTime;
        timerShoot += Time.deltaTime;

        CheckOutOfBounds();
        
        // 'Jump' is the keyword for spacebar
        if (Input.GetButton("Jump") && (timerShoot > 0.2f) && !GameObject.Find("Player_Projectile(Clone)")) {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            timerShoot = 0;
        }
    }

    void FixedUpdate()
    {
        movementDirection = Input.GetAxisRaw("Horizontal"); // fixes jitter movement bug

        if (timerMove >= 0.01f) {
            if (movementDirection == 1) { // right
                transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
            } else if (movementDirection == -1) { // left
                transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
            }

            timerMove = 0;
        }
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.x < -xRange) {
            transform.position = new Vector2(-xRange, transform.position.y); }

        if (transform.position.x > xRange) {
            transform.position = new Vector2(xRange, transform.position.y); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.CompareTag("Enemy_Projectile")) {
            Destroy(other.gameObject);
            gameManager.PlayerDied();
            Player_Lives.text = "PlayerLives: " + gameManager.Get_playerLives();
            Destroy(Instantiate(Explosion, transform.position, transform.rotation), 0.2f);
            Destroy(gameObject);
        }

        if(CallOnlyOneTime){ // call only one time even multiple enemies collide with player 
            if (other.gameObject.CompareTag("Enemy")) {
                gameManager.PlayerDied();
                Player_Lives.text = "PlayerLives: " + gameManager.Get_playerLives();
                Destroy(Instantiate(Explosion, transform.position, transform.rotation), 0.2f);
                Destroy(gameObject);
                CallOnlyOneTime = false;  
            }
        }
        else { CallOnlyOneTime = true;}
        
    }
}
