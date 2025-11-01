using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallBreakout ball = collision.gameObject.GetComponent<BallBreakout>();

        if(ball != null)
        {
            gameObject.SetActive(false);
        }
    }
}
