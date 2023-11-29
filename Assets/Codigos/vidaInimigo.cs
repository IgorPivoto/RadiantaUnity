using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaInimigo : MonoBehaviour
{
    [SerializeField] internal int quantidadeVida;
    [SerializeField] GameObject corpoDoInimigo;

   
    internal void Vida(int dano)
    {
        quantidadeVida -= dano;
        MorteInimigo();
    }
    internal void MorteInimigo()
    {
        if(quantidadeVida <=0)
        {
            corpoDoInimigo.SetActive(false);
        }
    }
}
