using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    #region variavel

    [SerializeField] float velocidadeInimigo;

    [SerializeField] int ataque;


    public Transform jogador;

    #endregion

    void Update()
    {
        Movimento();
        
    }

    void Movimento()
    {
        Vector2 direcao = jogador.position - transform.position;
        direcao.Normalize();
        transform.Translate(direcao * velocidadeInimigo * Time.deltaTime);
    }

    void Ativar()
    {
        if (this != null)
        {
            this.enabled = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Eva"))
        {
            VidaEva evaVida = other.gameObject.GetComponent<VidaEva>();
            Eva eva = other.gameObject.GetComponent<Eva>();
            evaVida.RemoveVida(ataque);
            eva.FeedBackDano();
            this.enabled = false;
        }      
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Eva"))
        {
            this.enabled = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("ia"))
        {
            Destroy(this);
        }
    }
}
