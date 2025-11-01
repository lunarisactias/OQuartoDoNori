using TMPro;
using UnityEngine;

public class QCHighlight : MonoBehaviour
{
    public Sprite noQCHighlight, qcHighlight;
    public TextMeshPro interagir;
    public SpriteRenderer SpriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SpriteRenderer.sprite = qcHighlight;
            interagir.gameObject.SetActive(true);
        }
        else
        {
            SpriteRenderer.sprite = noQCHighlight;
            interagir.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SpriteRenderer.sprite = noQCHighlight;
            interagir.gameObject.SetActive(false);
        }
        else
        {
            SpriteRenderer.sprite = qcHighlight;
            interagir.gameObject.SetActive(true);
        }
    }
}