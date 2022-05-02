using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public int direction;
    public float speed;
    private float yRange;
    private float timerMove;

    void Start()
    {
        yRange = 6.0f;
        timerMove = 0;
    }

    void Update()
    {
        timerMove += Time.deltaTime;
        if (timerMove > 0.01f) {
            Movement();
            timerMove = 0;
        }
    }

    private void Movement()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (direction * speed));
        if (Mathf.Abs(transform.position.y) > yRange) { Destroy(gameObject); }
    }
}
