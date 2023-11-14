using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecaGatilho : MonoBehaviour
{
    [SerializeField] string nomedatag;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Eva"))
        {
            
            GameObject inimigo = GameObject.FindGameObjectWithTag(nomedatag);

            if (inimigo != null)
            {
                inimigo.SendMessage("Ativar");
            }
        }
        
    }
}
