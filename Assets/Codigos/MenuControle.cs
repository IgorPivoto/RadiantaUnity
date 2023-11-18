using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControle : MonoBehaviour
{
     public GameObject PainelOpcoes;

    bool inativo;

    public void Jogar(string Entrar)
    {
    SceneManager.LoadScene(Entrar);
    }

    public void Opcao(string Entrar)
    {
        SceneManager.LoadScene(Entrar);
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

    public void InOpcoes()
    {
        inativo =! inativo;
        PainelOpcoes.SetActive(inativo);
    }
}
