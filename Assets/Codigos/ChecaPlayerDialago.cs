using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecaPlayerDialago : MonoBehaviour
{
    

    
   

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Dialago dialago = GetComponent<Dialago>();
        if(other.CompareTag("Eva"))
        {
            Debug.Log("ativei o script de dialago");
            dialago.enabled = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        Dialago dialago = GetComponent<Dialago>();
        if(other.CompareTag("Eva"))
        {
            Debug.Log("desativei o script de dialago");
            dialago.enabled = false;
        }
    }
}
