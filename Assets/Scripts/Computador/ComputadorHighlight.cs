using TMPro;
using UnityEngine;

public class ComputadorHighlight : MonoBehaviour
{
    public Sprite computadorHighlight, noComputadorHighlight, cadeiraHighlight, noCadeiraHighlight;
    public TextMeshPro interagir;
    public SpriteRenderer rendererComputador, rendererCadeira;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            rendererComputador.sprite = computadorHighlight;
            rendererCadeira.sprite = cadeiraHighlight;
            interagir.gameObject.SetActive(true);
        }
        else
        {
            rendererComputador.sprite = noComputadorHighlight;
            rendererCadeira.sprite = noCadeiraHighlight;
            interagir.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            rendererComputador.sprite = noComputadorHighlight;
            rendererCadeira.sprite = noCadeiraHighlight;
            interagir.gameObject.SetActive(false);
        }
        else
        {
            rendererComputador.sprite = computadorHighlight;
            rendererCadeira.sprite = cadeiraHighlight;
            interagir.gameObject.SetActive(true);
        }
    }
}
