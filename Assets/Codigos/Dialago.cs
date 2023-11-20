using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dialago : MonoBehaviour
{

    //[SerializeField] Sprite perfil;
    [SerializeField] string[] textoDialago;
    [SerializeField] string nomeAtorDialago;

    [SerializeField] LayerMask playerLayer;
    [SerializeField] float raio;

    private Controle_Dialago cd;
    bool naArea;
    
    internal bool falando = false;

    
    private void Start() 
    {
        cd =  FindAnyObjectByType<Controle_Dialago>();
    }

    private void FixedUpdate() 
    {   
        
        InteraçãoDialago();
        
     
    }
    private void Update() 
    {   
        
        if(Input.GetKeyDown(KeyCode.T) && naArea && falando == false)
        {
            
            cd.Discurso(/*perfil,*/ textoDialago, nomeAtorDialago);
            falando = true;
            

        }
    }

    public void InteraçãoDialago()
    {
       
        
        Collider2D hit = Physics2D.OverlapCircle(transform.position, raio, playerLayer);

        if (hit != null)
        {
            naArea = true;
            
            Debug.Log("entrei na area");
        }
        else 
        {
            naArea = false;
            
            Debug.Log("sai da area");
        }
        
    
        
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, raio);   
    }
    
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Eva"))
        {
            naArea = false;
            Debug.Log("saiu do triger");
        }
    }
    internal void PodeFalar(){
        falando = false;
    }
}
