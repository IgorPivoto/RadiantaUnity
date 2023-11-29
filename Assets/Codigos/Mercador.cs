using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercador : MonoBehaviour
{
    public GameObject MercadorPainel;
    private Eva eva;

    bool inativo;
    public bool podeAbrir = false;

    void Start()
    {
        eva = FindObjectOfType<Eva>();
    }

    void Update()
    {
        if (inativo == true)
        {
            if (eva != null)
            {
                eva.velocidadeAtual = 0;
            }
        }
        else
        {
            if (eva != null)
            {
                eva.velocidadeAtual = 3;
            }
        }

        if (podeAbrir == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                MercadorFunc();
            }
        }
    }

    public void MercadorFunc()
    {
        inativo = !inativo;
        MercadorPainel.SetActive(inativo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Eva"))
        {
            podeAbrir = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Eva"))
        {
            podeAbrir = false;
        }
    }
}