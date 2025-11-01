using UnityEngine;
using System.IO;

public class MenuDesenho : MonoBehaviour
{
    public GameObject caderno, quartoSemColisao, quartoComColisao, Nori;

    float elapsedTime = 0f;
    bool measureTime = false;
    string playerName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerName = GameManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Nome da Criança: " + playerName);

        if (caderno.activeSelf)
        {
            StartTimer();
        }
        if (!caderno.activeSelf)
        {
            StopTimer();
        }
        if (measureTime)
        {
            elapsedTime += Time.unscaledDeltaTime;
        }
    }

    public void SairDesenho()
    {
        caderno.SetActive(false);
        quartoComColisao.SetActive(true);
        quartoSemColisao.SetActive(false);
        Nori.GetComponent<Collider2D>().enabled = true;
        Nori.GetComponent<Player>().moveSpeed = 2;
        Nori.GetComponent<Animator>().enabled = true;
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
    private void WriteStuffToFile()
    {
        Debug.Log("Arquivo Salvo");

        Directory.CreateDirectory(Application.persistentDataPath + "\\Desenho");

        int elapsedTimeInt = (int)elapsedTime;
        string elapsedTimeString = "Tempo desenhando: " + elapsedTimeInt.ToString() + " segundos.";
        File.WriteAllText(Application.persistentDataPath + "\\Desenho\\" + playerName + " " + GameManager.Instance.date + ".txt", elapsedTimeString);
    }
}
