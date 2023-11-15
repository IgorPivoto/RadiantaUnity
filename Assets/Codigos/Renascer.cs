using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renascer : MonoBehaviour
{


    [SerializeField] GameObject portaoFinaldaVila;

    
    
    bool renascer1=false;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {   
        
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
                    timer = 0;
                }   
            }
        }
        
       
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("RenascerFimVila")){
            renascer1 = true;
            Debug.Log(renascer1);
        }
    }
}
