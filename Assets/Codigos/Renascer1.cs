using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renascer1 : MonoBehaviour
{
    [SerializeField] GameObject portaoFinaldaVila;
    [SerializeField] string tagsLocal;
    bool renascer1=false;
    float timer = 0;

    internal int numeroDeRespawn = 4;

    void Update()
    {   
        //Debug.Log(numeroDeRespawn);
        Eva eva = gameObject.GetComponent<Eva>();
        VidaEva vidaEva = gameObject.GetComponent<VidaEva>();
        if (renascer1 == true)
        {
            if(vidaEva.vida == 0)
            {
                timer += Time.deltaTime;
                
                if(timer >= 3.0f)
                {
                   
                    eva.transform.position = portaoFinaldaVila.transform.position;
                    vidaEva.vida = 100;
                    eva.estamina = 100;
                    timer = 0;
                    numeroDeRespawn ++;
                }   
            }
        }
        
       
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Renascer renascer = GetComponent<Renascer>();
        if(other.CompareTag(tagsLocal))
        {
            renascer1 = true;
            renascer.enabled = false;
        }
    }
}
