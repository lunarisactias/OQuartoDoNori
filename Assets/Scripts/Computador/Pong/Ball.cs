using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI playerScore;
    [SerializeField] TMPro.TextMeshProUGUI AIScore;
    public float speed = 200.0f;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rb2d.AddForce(direction * speed);
    }

    public void ResetBall()
    {
        if (transform.position.x > 0)
        {
            transform.localPosition = new Vector2(0,0);
            rb2d.linearVelocity = Vector3.zero;
            AddStartingForce();
        }
        else if (transform.position.x < 0)
        {
            transform.localPosition = new Vector2(0,0);
            rb2d.linearVelocity = Vector3.zero;
            AddStartingForce();
        }
        else
        {
            transform.localPosition = new Vector2(0, 0);
            rb2d.linearVelocity = Vector3.zero;
            AddStartingForce();
        }
    }
}
