using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : Raquete
{
    public Rigidbody2D ball;

    private void FixedUpdate()
    {
        if (ball.linearVelocity.x > 0.0f)
        {
            if (ball.position.y > transform.position.y)
            {
                rb2d.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < transform.position.y)
            {
                rb2d.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            if (transform.position.y > 0.0f)
            {
                rb2d.AddForce(Vector2.down * speed);
            }
            else if (transform.position.y < 0.0f)
            {
                rb2d.AddForce(Vector2.up * speed);
            }
        }
    }
}