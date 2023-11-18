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
    }

    public void MenuPrincipal(string voltar)
    {
        SceneManager.LoadScene(voltar);
    }
}
