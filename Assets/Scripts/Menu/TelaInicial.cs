using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaInicial : MonoBehaviour
{
    public string playerName;
    public GameObject jogarButton;
    public GameObject sairButton;
    public GameObject nomeInputField;
    public TextMeshProUGUI nameText;

    public void Jogar()
    {
        SceneManager.LoadScene("Quarto");
    }
    public void Sair()
    {
        Application.Quit();
    }

    public void GetName()
    {
        playerName = nameText.text;
        Debug.Log("Nome da Criança: " + playerName);
    }

    public void ConfirmName()
    {
        jogarButton.SetActive(true);
        sairButton.SetActive(true);
        nomeInputField.SetActive(false);
    }
}
