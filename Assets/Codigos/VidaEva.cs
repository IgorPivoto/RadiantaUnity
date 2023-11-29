using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class VidaEva : MonoBehaviour
{

    #region varival

    [SerializeField] internal int vida;

    #endregion


    void Update()
    {
        Eva eva = GetComponent<Eva>();
        if(vida > 0){
            
            eva.enabled = true;
            
        }
    }
   
    public void RemoveVida(int dano)
    {
        vida -= dano;
    }

}
