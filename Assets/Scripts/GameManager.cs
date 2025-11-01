using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TelaInicial telaInicial;
    public string playerName;
    public string date;
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        date = System.DateTime.Now.ToString("dd-MM-yyyy HH'hrs'mm'mins'");
        if (telaInicial != null)
        {
            playerName = telaInicial.playerName;
        }
    }
}
