using System.IO;
using UnityEngine;

public class MenuPiano : MonoBehaviour
{
    public GameObject piano, quartoSemColisao, quartoComColisao, Nori;
    GameObject[] notas;
    string playerName;

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
        if (piano.activeSelf)
        {
            StartTimer();
        }
        if (!piano.activeSelf)
        {
            StopTimer();
        }
        if (measureTime)
        {
            elapsedTime += Time.unscaledDeltaTime;
        }
        GetMeasuredTime();
        Debug.Log("Tempo no Piano: " + elapsedTime);
        notas = GameObject.FindGameObjectsWithTag("Nota");
    }

    public void SairPiano()
    {
        piano.SetActive(false);
        quartoComColisao.SetActive(true);
        quartoSemColisao.SetActive(false);
        Nori.GetComponent<Collider2D>().enabled = true;
        Nori.GetComponent<Player>().moveSpeed = 2;
        Nori.GetComponent<Animator>().enabled = true;
        foreach (var nota in notas)
        {
            nota.SetActive(false);
        }
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
        Directory.CreateDirectory(Application.persistentDataPath + "\\Piano");
        int elapsedTimeInt = (int)elapsedTime;
        string elapsedTimeString = "Tempo no piano: " + elapsedTimeInt.ToString() + " segundos.";
        File.WriteAllText(Application.persistentDataPath + "\\Piano\\" + playerName + " " + GameManager.Instance.date + ".txt", elapsedTimeString);
    }
}
