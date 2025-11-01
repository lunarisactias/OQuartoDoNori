using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Vector2 movement;
    Rigidbody2D rb;
    Animator animator;
    Collider2D colisaoNori;
    string lastHorizontal = "LastHorizontal";
    string lastVertical = "LastVertical";
    public bool pausado = false;
    public string dtString;

    public GameObject cilada, computador, desenho, piano, quebracabecas, quartoSemColisao, quartoComColisao, pausa;

    private bool inComputadorMinigame, inDesenhoMinigame, inPianoMinigame, inQCMinigame, inCilada;
    void Start()
    {
        colisaoNori = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        computador.SetActive(false);
        cilada.SetActive(false);
        desenho.SetActive(false);
        piano.SetActive(false);
        quartoSemColisao.SetActive(false);
        quebracabecas.SetActive(false);
    }

    void Update()
    {
        DateTime dt = DateTime.Now;
        dtString = dt.ToString("dd/MM/yyyy HH:mm:ss \"GMT\"zzz");

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
            animator.SetBool("isMoving", true);
        }
        else
        {
            movement.x = 0;
            animator.SetBool("isMoving", true);
        }
        movement = new Vector2(movement.x, movement.y);
        if (movement.x == 0 & movement.y == 0)
        {
            animator.SetBool("isMoving", false);
        }
        rb.linearVelocity = movement * moveSpeed;
        animator.SetFloat("xMove", movement.x);
        animator.SetFloat("yMove", movement.y);

        if (movement != Vector2.zero)
        {
            animator.SetFloat(lastHorizontal, movement.x);
            animator.SetFloat(lastVertical, movement.y);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado == false)
            {
                pausa.SetActive(true);
                pausado = true;
                Time.timeScale = 0f;
            }
            else
            {
                pausa.SetActive(false);
                pausado = false;
                Time.timeScale = 1f;
            }

        }

        //Minigames

        if(inComputadorMinigame && Input.GetKeyDown(KeyCode.E))
        {
            computador.SetActive(true);
            Debug.Log("entrou no pc");
            quartoSemColisao.SetActive(true);
            quartoComColisao.SetActive(false);
            colisaoNori.enabled = false;
            animator.enabled = false;
            moveSpeed = 0;
        }

        if (inDesenhoMinigame && Input.GetKeyDown(KeyCode.E))
        {
            desenho.SetActive(true);
            Debug.Log("entrou no desenho");
            quartoSemColisao.SetActive(true);
            quartoComColisao.SetActive(false);
            colisaoNori.enabled = false;
            animator.enabled = false;
            moveSpeed = 0;
        }

        if (inPianoMinigame && Input.GetKeyDown(KeyCode.E))
        {
            piano.SetActive(true);
            Debug.Log("entrou no piano ");
            quartoSemColisao.SetActive(true);
            quartoComColisao.SetActive(false);
            colisaoNori.enabled = false;
            animator.enabled = false;
            moveSpeed = 0;
        }
        if (inQCMinigame && Input.GetKeyDown(KeyCode.E))
        {
            quebracabecas.SetActive(true);
            Debug.Log("entrou no quebra cabeças");
            quartoSemColisao.SetActive(true);
            quartoComColisao.SetActive(false);
            colisaoNori.enabled = false;
            animator.enabled = false;
            moveSpeed = 0;
        }
        if (inCilada && Input.GetKeyDown(KeyCode.E))
        {
            cilada.SetActive(true);
            Debug.Log("entrou na cilada");
            quartoSemColisao.SetActive(true);
            quartoComColisao.SetActive(false);
            colisaoNori.enabled = false;
            animator.enabled = false;
            moveSpeed = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Computador"))
        {
            inComputadorMinigame = true;
            Debug.Log("entrou na area do pc");
        }

        if (collision.CompareTag("Desenho"))
        {
            inDesenhoMinigame = true;
        }

        if (collision.CompareTag("Piano"))
        {
            inPianoMinigame = true;
        }
        if (collision.CompareTag("MinigameQC"))
        {
            inQCMinigame = true;
        }
        if (collision.CompareTag("Cilada"))
        {
            inCilada = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Computador"))
        {
            inComputadorMinigame = false;
        }

        if (collision.CompareTag("Desenho"))
        {
            inDesenhoMinigame = false;
        }

        if (collision.CompareTag("Piano"))
        {
            inPianoMinigame = false;
        }

        if (collision.CompareTag("MinigameQC"))
        {
            inQCMinigame = false;
        }
        if (collision.CompareTag("Cilada"))
        {
            inCilada = false;
        }
    }
}
