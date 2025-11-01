using UnityEngine;

public class Invasor : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime;
    public int score = 10;

    public System.Action killed;
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpriteIndex = 0;
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        currentSpriteIndex++;

        if (currentSpriteIndex >= animationSprites.Length)
        {
            currentSpriteIndex = 0;
        }

        spriteRenderer.sprite = animationSprites[currentSpriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            SIGameManager.Instance.OnInvaderKilled(this);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            SIGameManager.Instance.OnBoundaryReached();
        }
    }
}
