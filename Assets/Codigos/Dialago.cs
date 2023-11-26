using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;



public class Dialago : MonoBehaviour
{

    [SerializeField] string[] textoDialago;
    [SerializeField] string nomeAtorDialago;

    [SerializeField] LayerMask playerLayer;
    [SerializeField] float raio;

    private Controle_Dialago cd;
    
    
    public bool naArea;
    
    public bool falando = false;

    //public bool travaCodigoDialago = true;
    
    private void Start() 
    {
        cd =  FindObjectOfType<Controle_Dialago>();
    }
    
    private void FixedUpdate() 
    {   
        
        InteraçãoDialago(); 
    }
    private void Update() 
    {   
        //Debug.Log("trava codigo " + travaCodigoDialago);
        Debug.Log("falando" + falando);
        Debug.Log("estou na area "+ naArea);
        
        if(Input.GetKeyDown(KeyCode.T) && naArea && falando == false)
        {
            
            cd.Discurso(textoDialago, nomeAtorDialago);
            falando = true;
            

        }
        
    }

    public void InteraçãoDialago()
    {
       
        
        Collider2D hit = Physics2D.OverlapCircle(transform.position, raio, playerLayer);

        if (hit != null)
        {
            naArea = true;
            
            Debug.Log("entrei na area" + naArea);
        }
        else 
        {
            naArea = false;
            
            Debug.Log("sai da area" + naArea);
        }
        
    
        
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, raio);   
    }
    
    
    internal void PodeFalar(){
        falando = false;
        Debug.Log("estou podendo falar");
        Debug.Log("posso falar? " + falando);
    }
    
}
