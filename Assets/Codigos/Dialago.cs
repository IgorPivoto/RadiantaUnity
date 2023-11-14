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
    private void Start() 
    {
        cd =  FindAnyObjectByType<Controle_Dialago>();
    }

    private void FixedUpdate() 
    {
        InteraçãoDialago();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && naArea)
        {
            cd.Discurso(/*perfil,*/ textoDialago, nomeAtorDialago);
        }
    }

    public void InteraçãoDialago()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, raio, playerLayer);

        if(hit != null)
        {
            naArea = true;
        }
        else
        {
            naArea = false;
        }
    
        
    }
    private void OnDrawGizmosSelected() 
    {
     Gizmos.DrawWireSphere(transform.position, raio);   
    }

}
