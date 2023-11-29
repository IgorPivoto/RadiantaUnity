using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaInimigo : MonoBehaviour
{
    [SerializeField] internal int quantidadeVida;
    [SerializeField] GameObject corpoDoInimigo;

    void Start()
    {
        
    }
    void Update()
    {
        MorteInimigo();
    }
    internal void Vida(int dano)
    {
        quantidadeVida -= dano;
    }
    internal void MorteInimigo()
    {
        if(quantidadeVida <=0)
        {
            corpoDoInimigo.SetActive(false);
        }
    }
}
