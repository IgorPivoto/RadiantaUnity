using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiserCode : MonoBehaviour
{
    public float speed = 5f; 
    private Vector2 direcaoDoJogador; 
    void Start()
    {
        GameObject jogadorObjeto = GameObject.FindGameObjectWithTag("Eva");

        if (jogadorObjeto != null)
        {
          
            direcaoDoJogador = (jogadorObjeto.transform.position - transform.position).normalized;
        }
        else
        {
            Debug.LogError("Não foi possível encontrar o jogador. Certifique-se de que o jogador tem a tag 'Player'.");
        }

    
        transform.Translate(direcaoDoJogador * speed * Time.deltaTime, Space.World);
    }

    void Update()
    {
       
        transform.Translate(direcaoDoJogador * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barreira"))
        {
            Destroy(gameObject);
        }
    }
}
