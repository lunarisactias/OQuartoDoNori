using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void SairPausa()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        player.GetComponent<Player>().pausado = false;
    }
}
