using UnityEngine;

public class RaqueteBreakout : MonoBehaviour
{
    //velocidade da raquete
    public float speed = 10.0f;

    protected Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}
