using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurfaceBreakout : MonoBehaviour
{
    [SerializeField] BallBreakout ball;
    public float strength;
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Vector2 normal = collision.GetContact(0).normal;
            ball.rb2d.AddForce(-normal * strength);
    }
}
