using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltarDaArena : MonoBehaviour
{
    [SerializeField] KeyCode teclaTeleporte = KeyCode.T;
    [SerializeField] Vector3 coordenadasDestino;
    [SerializeField] GameObject jogador;
    

    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Eva"))
        {
            if(Input.GetKeyDown(teclaTeleporte))
            {
                Teleportar();
            }
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
}
