using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausar : MonoBehaviour
{
    public GameObject MenuPausarObj;

    bool inativo;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           Menu();
        }
    }

    public void Menu()
    {
        inativo =! inativo;
        MenuPausarObj.SetActive(inativo);
        if (inativo)
        {
            PausarJogo();
            // Ative aqui o seu menu de pausa
            MenuPausarObj.SetActive(true);
        }
        else
        {
            RetomarJogo();
            // Desative aqui o seu menu de pausa
            MenuPausarObj.SetActive(false);
        }
    }
    void PausarJogo()
    {
        Time.timeScale = 0f;
    }

    void RetomarJogo()
    {
        Time.timeScale = 1f;
    }

    public void MenuPrincipal(string voltar)
    {
        SceneManager.LoadScene(voltar);
    }
}
