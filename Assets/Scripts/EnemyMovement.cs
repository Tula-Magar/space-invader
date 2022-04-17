using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject projectile;

    private float movementDirection;
    private float timerMove;
    private float timerShoot;
    private float xRange;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.AddEnemy(gameObject);   // modified Observer pattern

        movementDirection = -1;
        xRange = 9.0f;
    }

    void Update()
    {
        timerMove += Time.deltaTime;
        timerShoot += Time.deltaTime;

        CheckOutOfBounds();

        if (timerShoot > 3.0f)
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            timerShoot = 0;
        }
    }

    void FixedUpdate()
    {
        if (timerMove > 1.0f)
        {
            if (movementDirection == 1)
            { // right
                transform.position = new Vector2(transform.position.x + 1.0f, transform.position.y);
            }
            else if (movementDirection == -1)
            { // left
                transform.position = new Vector2(transform.position.x - 1.0f, transform.position.y);
            }
            timerMove = 0;
        }
    }

    private void CheckOutOfBounds()
    {
        if (Mathf.Abs(transform.position.x) >= xRange) { gameManager.EnemiesChangeDirection(); }
    }

    public void ChangeDirection()
    {
        if (movementDirection == 1)
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
            movementDirection = -1;
        }
        else
        {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
            movementDirection = 1;
        }
    }
}
