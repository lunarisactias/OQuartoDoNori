using TMPro;
using UnityEngine;

public class PianoHighlight : MonoBehaviour
{

    public Sprite noPianoHighlight, pianoHighlight;
    public TextMeshPro interagir;
    public SpriteRenderer SpriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SpriteRenderer.sprite = pianoHighlight;
            interagir.gameObject.SetActive(true);
        }
        else
        {
            SpriteRenderer.sprite = noPianoHighlight;
            interagir.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SpriteRenderer.sprite = noPianoHighlight;
            interagir.gameObject.SetActive(false);
        }
        else
        {
            SpriteRenderer.sprite = pianoHighlight;
            interagir.gameObject.SetActive(true);
        }
    }
}
