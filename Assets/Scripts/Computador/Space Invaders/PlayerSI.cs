using UnityEngine;

public class PlayerSI : MonoBehaviour
{
    public ProjeteisSI projectilePrefab;
    public float speed = 5f;
    private bool laserActive;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (!laserActive)
        {
            ProjeteisSI projectile = Instantiate(this.projectilePrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            laserActive = true;
        }
    }

    private void LaserDestroyed()
    {
        laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Invader") ||
            collision.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            SIGameManager.Instance.OnPlayerKilled(this);
        }
    }
}
