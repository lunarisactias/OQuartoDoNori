using UnityEngine;

public class PlayerBreakout : Raquete
{
    private Vector2 direction;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if(direction.sqrMagnitude != 0)
        {
            rb2d.AddForce(direction * speed);
        }
    }
}
