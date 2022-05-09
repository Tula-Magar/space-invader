using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameManager gameManager;
    private EnemyManager enemyManager;
    public GameObject Explosion;
    
    private float movementDirection;
    private float timerMove;
    private float xRange;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        enemyManager.AddEnemy(gameObject);   // modified Observer pattern

        movementDirection = -1;
        xRange = 9.0f;
    }

    void Update()
    {
        timerMove += Time.deltaTime;

        CheckOutOfBounds();
    }

    void FixedUpdate()
    {
        // move once every second
        if (timerMove > 1.0f) {
            transform.position = new Vector2(transform.position.x + movementDirection, transform.position.y);
            timerMove = 0;
        }
    }

    // if at boundary of screen, alert the EnemyManager to change the direction of the entire wave
    private void CheckOutOfBounds()
    {
        if (Mathf.Abs(transform.position.x) >= xRange) { enemyManager.EnemiesChangeDirection(); }
    }

    // called by EnemyManager to control wave behavior
    public void ChangeDirection()
    {
        if (movementDirection == 1) {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
            movementDirection = -1;
        }
        else {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
            movementDirection = 1;
        }
    }

    // collision detected, heavy lifting done by Unity's MonoBehaviour
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Projectile")) {
            enemyManager.RemoveEnemy(gameObject);
            Destroy(Instantiate(Explosion, transform.position, transform.rotation), 0.2f);
            gameManager.ScoreNum = 1;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
