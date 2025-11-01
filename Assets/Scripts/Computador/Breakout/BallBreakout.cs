 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallBreakout : MonoBehaviour
{
    public float speed = 200.0f;
    public Rigidbody2D rb2d;
    GameObject[] blocos, blocosUpdate;
    public float angleForce = 1.0f;
    public TextMeshProUGUI win;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        AddStartingForce();
        blocos = GameObject.FindGameObjectsWithTag("Bloco");
    }
    private void Update()
    {
        blocosUpdate = GameObject.FindGameObjectsWithTag("Bloco");
        if (blocosUpdate.Length == 0)
        {
            Win();
        }
        else
        {
            win.gameObject.SetActive(false);
        }
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rb2d.AddForce(direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject bloco in blocos)
        {
            bloco.SetActive(true);
        }
        transform.localPosition = new Vector2(1, 1);
        rb2d.linearVelocity = Vector3.zero;
        AddStartingForce();
    }

    void Win()
    {
        rb2d.linearVelocity = Vector3.zero;
        win.gameObject.SetActive(true);
    }
}
