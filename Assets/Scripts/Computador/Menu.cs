using UnityEngine;
using TMPro;
using System.IO;
public class Menu : MonoBehaviour
{
    public GameObject Pong, Breakout, SpaceInvaders, Computador, menuComputador, quartoSemColisao, quartoComColisao, Nori;
    public TextMeshProUGUI playerScore, cpuScore;
    [SerializeField] Ball Ball;
    [SerializeField] BallBreakout BallBreakout;
    private string playerName;
    float elapsedTime = 0f;
    bool measureTime = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerName = GameManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        if (Computador.activeSelf)
        {
            StartTimer();
        }
        if (!Computador.activeSelf)
        {
            StopTimer();
        }
        if (measureTime)
        {
            elapsedTime += Time.unscaledDeltaTime;
        }
    }

    public void AbrirPong()
    {
        Pong.SetActive(true);
        menuComputador.SetActive(false);
        Ball.ResetBall();
    }
    public void AbrirBreakout()
    {
        Breakout.SetActive(true);
        menuComputador.SetActive(false);
    }
    public void AbrirSpaceInvaders()
    {
        SpaceInvaders.SetActive(true);
        menuComputador.SetActive(false);
    }
    public void AbrirJogo4() 
    {
        menuComputador.SetActive(false);
    }
    public void DesligarComputador()
    {
        if (SIGameManager.Instance != null)
        {
            SIGameManager.Instance.NewGame();
        }
        playerScore.text = "0";
        cpuScore.text = "0";
        SpaceInvaders.SetActive(false);
        Breakout.SetActive(false);
        Pong.SetActive(false);
        menuComputador.SetActive(true);
        Computador.SetActive(false);
        quartoComColisao.SetActive(true);
        quartoSemColisao.SetActive(false);
        Nori.GetComponent<Collider2D>().enabled = true;
        Nori.GetComponent<Player>().moveSpeed = 2;
        Nori.GetComponent<Animator>().enabled = true;
    }
    public void VoltarMenu()
    {
        if (SIGameManager.Instance != null)
        {
            SIGameManager.Instance.NewGame();
        }
        playerScore.text = "0";
        cpuScore.text = "0";
        SpaceInvaders.SetActive(false);
        Breakout.SetActive(false);
        Pong.SetActive(false);
        menuComputador.SetActive(true);
    }

    private void OnDestroy()
    {
        WriteStuffToFile();
        ResetTimer();
    }
    void StartTimer()
    {
        measureTime = true;
    }

    void StopTimer()
    {
        measureTime = false;
    }

    void ResetTimer()
    {
        elapsedTime = 0f;
    }
    float GetMeasuredTime()
    {
        return elapsedTime;
    }
    private void WriteStuffToFile()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "\\Computador");
        int elapsedTimeInt = (int)elapsedTime;
        string elapsedTimeString = "Tempo no computador: " + elapsedTimeInt.ToString() + " segundos.";
        File.WriteAllText(Application.persistentDataPath + "\\Computador\\" + playerName + " " + GameManager.Instance.date + ".txt", elapsedTimeString);
    }
}
