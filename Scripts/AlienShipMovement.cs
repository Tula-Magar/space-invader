using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShipMovement : MonoBehaviour
{
    private GameManager gameManager;

    private float movementDirection;
    private float timerMove;
    private float xRange;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        xRange = 11.0f;

        if (transform.position.x == -10) { movementDirection = 0.1f; }
        else { movementDirection = -0.1f; }
    }

    void Update()
    {
        timerMove += Time.deltaTime;
        if (timerMove > 0.01f) {
            transform.position = new Vector2(transform.position.x + movementDirection, transform.position.y);
            timerMove = 0;
        }

        if (Mathf.Abs(transform.position.x) >= xRange) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Projectile")) {
            gameManager.ScoreNum = 3;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
