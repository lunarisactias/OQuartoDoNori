using UnityEngine;

public class ProjeteisSI : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);

        if (this.destroyed != null)
        {
            this.destroyed.Invoke();
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void CheckCollision(Collider2D other)
    {
        Bunker bunker = other.gameObject.GetComponent<Bunker>();

        if (bunker == null || bunker.CheckCollision(boxCollider, transform.position))
        {
            Destroy(gameObject);
        }
    }
}
