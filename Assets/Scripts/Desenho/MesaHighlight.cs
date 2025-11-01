using TMPro;
using UnityEngine;

public class MesaHighlight : MonoBehaviour
{
    public Sprite noMesaHighlight, mesaHighlight;
    public TextMeshPro interagir;
    public SpriteRenderer SpriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SpriteRenderer.sprite = mesaHighlight;
            interagir.gameObject.SetActive(true);
        }
        else
        {
            SpriteRenderer.sprite = noMesaHighlight;
            interagir.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SpriteRenderer.sprite = noMesaHighlight;
            interagir.gameObject.SetActive(false);
        }
        else
        {
            SpriteRenderer.sprite = mesaHighlight;
            interagir.gameObject.SetActive(true);
        }
    }
}
