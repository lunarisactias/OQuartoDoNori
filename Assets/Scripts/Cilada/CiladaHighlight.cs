using TMPro;
using UnityEngine;

public class CiladaHighlight : MonoBehaviour
{
    public Sprite ciladaHighlight, noCiladaHighlight;
    public TextMeshPro interagir;
    public SpriteRenderer rendererCilada;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            rendererCilada.sprite = ciladaHighlight;
            interagir.gameObject.SetActive(true);
        }
        else
        {
            rendererCilada.sprite = ciladaHighlight;
            interagir.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            rendererCilada.sprite = noCiladaHighlight;
            interagir.gameObject.SetActive(false);
        }
        else
        {
            rendererCilada.sprite = ciladaHighlight;
            interagir.gameObject.SetActive(true);
        }
    }
}
