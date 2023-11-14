using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoUniversal : MonoBehaviour
{

    #region variavel

    [SerializeField] GameObject barreira;

    [SerializeField] bool estado;

    #endregion

    void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.CompareTag("Eva"))
        {         
            barreira.SetActive(estado);
        }
    }
}
