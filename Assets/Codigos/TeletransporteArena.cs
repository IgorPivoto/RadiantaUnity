using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransporteArena : MonoBehaviour
{
    [SerializeField] KeyCode teclaTeleporte = KeyCode.T;
    [SerializeField] Vector3 coordenadasDestino;
    [SerializeField] GameObject jogador;
    [SerializeField] float raio;
    [SerializeField] LayerMask playerLayer;

    bool naArea = false;
    
    private void FixedUpdate() 
    {     
        Area();  
    }
    void Update() 
    {     
        if(Input.GetKeyDown(teclaTeleporte) && naArea == true)
        {
            Teleportar();
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Eva"))
        {
            
        }
    }

    void Area()
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

    void Teleportar()
    {
        if (jogador != null)
        {
            jogador.transform.position = coordenadasDestino;
        }
        else
        {
            Debug.LogError("Jogador não encontrado. Certifique-se de ter marcado o jogador com a tag 'Player'.");
        }
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, raio);   
    }
}
