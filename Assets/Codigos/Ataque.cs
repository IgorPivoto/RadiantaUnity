using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    [SerializeField] int danoAtaque;
    void OnTriggerEnter2D(Collider2D other)     
    {
        if(other.CompareTag("Inimigo"))
        {
            other.GetComponent<vidaInimigo>().Vida(danoAtaque);
        }    
        if(other.CompareTag("ia"))
        {
            other.GetComponent<VidaIA>().Vida(danoAtaque);
        } 
    }
}
