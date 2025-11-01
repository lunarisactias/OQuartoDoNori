using UnityEngine;

public class CiladaUI : MonoBehaviour
{
    public GameObject quartoSemColisao;
    public GameObject quartoComColisao;
    public GameObject Nori;
    public GameObject ciladaBorder;
    public GameObject ciladaHolder;
    public GameObject buttonGame1,
        buttonGame2,
        buttonGame3,
        buttonGame4,
        buttonGame5,
        buttonGame6,
        buttonGame7,
        buttonGame8,
        buttonGame9,
        buttonGame10;
    public GameObject buttonBack;
    public GameObject buttonExit;
    public GameObject cilada;
    public GameObject chooseText;
    public GameObject winPanel;

    public void BackButton()
    {
        CiladaManager.Instance.ResetPieces();
        ciladaBorder.SetActive(false);
        ciladaHolder.SetActive(false);
        buttonGame1.SetActive(true);
        buttonGame2.SetActive(true);
        buttonGame3.SetActive(true);
        buttonGame4.SetActive(true);
        buttonGame5.SetActive(true);
        buttonGame6.SetActive(true);
        buttonGame7.SetActive(true);
        buttonGame8.SetActive(true);
        buttonGame9.SetActive(true);
        buttonGame10.SetActive(true);
        buttonBack.SetActive(false);
        chooseText.SetActive(true);
        winPanel.SetActive(false);
    }

    public void ExitButton()
    {
        BackButton();
        cilada.SetActive(false);
        quartoComColisao.SetActive(true);
        quartoSemColisao.SetActive(false);
        Nori.GetComponent<Collider2D>().enabled = true;
        Nori.GetComponent<Player>().moveSpeed = 2;
        Nori.GetComponent<Animator>().enabled = true;
        winPanel.SetActive(false);
    }

    public void EnterGame()
    {
        CiladaManager.Instance.ResetPieces();
        ciladaHolder.SetActive(true);
        ciladaBorder.SetActive(true);
        buttonGame1.SetActive(false);
        buttonGame2.SetActive(false);
        buttonGame3.SetActive(false);
        buttonGame4.SetActive(false);
        buttonGame5.SetActive(false);
        buttonGame6.SetActive(false);
        buttonGame7.SetActive(false);
        buttonGame8.SetActive(false);
        buttonGame9.SetActive(false);
        buttonGame10.SetActive(false);
        chooseText.SetActive(false);
        buttonBack.SetActive(true);
    }

    public void Game1Button()
    {
        EnterGame();
        CiladaManager.Instance.Game1();
    }
    public void Game2Button()
    {
        EnterGame();
        CiladaManager.Instance.Game2();
    }
    public void Game3Button()
    {
        EnterGame();
        CiladaManager.Instance.Game3();
    }
    public void Game4Button()
    {
        EnterGame();
        CiladaManager.Instance.Game4();
    }
    public void Game5Button()
    {
        EnterGame();
        CiladaManager.Instance.Game5();
    }
    public void Game6Button()
    {
        EnterGame();
        CiladaManager.Instance.Game6();
    }
    public void Game7Button()
    {
        EnterGame();
        CiladaManager.Instance.Game7();
    }
    public void Game8Button()
    {
        EnterGame();
        CiladaManager.Instance.Game8();
    }
    public void Game9Button()
    {
        EnterGame();
        CiladaManager.Instance.Game9();
    }
    public void Game10Button()
    {
        EnterGame();
        CiladaManager.Instance.Game10();
    }
}
