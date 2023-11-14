using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEva : MonoBehaviour
{

    #region varival

    [SerializeField] internal int vida;

    #endregion

   
    public void RemoveVida(int dano)
    {
        vida = vida - dano;
    }
}
