using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI playerScore;
    [SerializeField] TMPro.TextMeshProUGUI AIScore;
    [SerializeField] Ball Ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (transform.position.x < 0)
            {
                playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
                Ball.ResetBall();   
            }
            if (transform.position.x > 0)
            {
                AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
                Ball.ResetBall();
            }
        }
    }
}
