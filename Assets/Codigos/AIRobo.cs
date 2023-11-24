using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AIRobo : MonoBehaviour                                 
{
    #region variavel

    [SerializeField] GameObject jogador;

    [SerializeField] float velocidadeInimigo;

    [SerializeField] GameObject inimigo;

    //[SerializeField] int vida;

    [SerializeField] int ataque;

    [SerializeField] Animator animEobo;

    
    float tempo = 0;

    private Vector3 pontoDeNascimento;
    private float distancia;

    public Transform Jogador;

    

    #endregion
    void Start() 
    {
        pontoDeNascimento = transform.position;    
    }
    void Update()
    {
        Movimento();
        
    }

    void Movimento()
    {
        Vector2 direcao = Jogador.position - transform.position;
        direcao.Normalize();
       
        animEobo.SetFloat("horizontal",direcao.x);
        animEobo.SetFloat("vertical",direcao.y);
        animEobo.SetFloat("velocidade",direcao.magnitude);

        transform.Translate(direcao * velocidadeInimigo * Time.deltaTime);
    }

    void Ativar()
    {
        if (this != null)
        {
            this.enabled = true;
        }
    }
    public void ResetarInimigo()
    {

        inimigo.transform.position = pontoDeNascimento;
    }

    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Eva"))
        {
            
            VidaEva evaVida = other.gameObject.GetComponent<VidaEva>();
            Eva eva = other.gameObject.GetComponent<Eva>();
            Renascer renascer = other.gameObject.GetComponent<Renascer>();
            evaVida.RemoveVida(ataque);
            eva.FeedBackDano();
            //eva.Morte();
            eva.anim.SetBool("morte",true);
            renascer.numeroDeRespawn ++;
            tempo += Time.deltaTime;
            Debug.Log(tempo);
            
            
            ResetarInimigo();
                
            
            inimigo.SetActive(false);
            

            
            //this.enabled = false;
        }      
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Eva"))
        {
            //this.enabled = true;
        }
    }

   
}
                                                                                                                                                                                                                                                                                          