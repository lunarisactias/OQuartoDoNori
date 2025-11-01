using UnityEditor;
using UnityEngine;

public class Invasores : MonoBehaviour
{
    public Transform cam;
    public Invasor[] prefabs;
    public int rows = 4;
    public int columns = 15;
    public float spacing = 60f;
    private Vector3 direction = Vector2.right;
    public AnimationCurve speed;
    public ProjeteisSI missilePrefab;
    public float missileAttackRate = 1f;
    private Vector3 initialPosition;
    public int amountKilled { get; private set; }
    public int amountAlive;
    public int totalInvaders => this.rows * this.columns;
    public float percentKilled;

    private void Awake()
    {
        initialPosition = transform.localPosition;

        for (int row = 0; row < this.rows; row++)
        {
            float width = spacing * (this.columns - 1);
            float height = spacing * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * spacing), 0.0f);

            for (int column = 0; column < this.columns; column++)
            {
                Invasor invasor = Instantiate(this.prefabs[row], this.transform);
                invasor.killed += InvaderKilled;
                Vector3 position = rowPosition;
                position.x += column * spacing;
                invasor.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);
    }

    private void Update()
    {
        int totalCount = rows * columns;
        amountAlive = GetAliveCount();
        amountKilled = totalCount - amountAlive;
        percentKilled = amountKilled / (float)totalCount;

        float speed = this.speed.Evaluate(percentKilled);

        this.transform.position += direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        Vector3 leftEdge = new Vector3((-3.3f + cam.transform.position.x),0,0);
        Vector3 rightEdge = new Vector3((3.3f + cam.transform.position.x), 0, 0);

        foreach (Transform invasor in this.transform)
        {
            if (!invasor.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (direction == Vector3.right && invasor.position.x >= rightEdge.x)
            {
                AdvanceRow();
                Debug.Log("if direita");
            }
            else if (direction == Vector3.left && invasor.position.x <= leftEdge.x)
            {
                AdvanceRow();
                Debug.Log("if esquerda");
            }
        }
    }

    private void AdvanceRow()
    {
        direction = new Vector3(-direction.x, 0f, 0f);

        Vector3 position = this.transform.position;
        position.y -= 0.15f;
        this.transform.position = position;
        Debug.Log("AdvanceRow");
    }

    public void ResetInvaders()
    {
        direction = Vector3.right;
        transform.localPosition = initialPosition;

        foreach (Transform invader in transform)
        {
            invader.gameObject.SetActive(true);
        }
    }

    private void MissileAttack()
    {
        foreach (Transform invasor in this.transform)
        {
            if (!invasor.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (Random.value < (1f / (float)this.amountAlive))
            {
                Instantiate(this.missilePrefab, invasor.position, Quaternion.identity);
                break;
            }
        }
    }

    private void InvaderKilled()
    {
        this.amountKilled++;

        if(this.amountKilled >= this.totalInvaders)
        {
            
        }
    }

    public int GetAliveCount()
    {
        int count = 0;

        foreach (Transform invader in transform)
        {
            if (invader.gameObject.activeSelf)
            {
                count++;
            }
        }
        return count;
    }
}
