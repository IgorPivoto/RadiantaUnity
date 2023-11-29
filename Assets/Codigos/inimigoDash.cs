using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoDash : MonoBehaviour
{
    private Transform jogador;
    [SerializeField] Vector2 pontoInicial = new Vector2(0, 0);
    [SerializeField] Vector2 pontoFinal = new Vector2(0, 0);
    [SerializeField] float velocidade = 2.0f;
    [SerializeField] float velocidadeDash = 10.0f;
    [SerializeField] float alcance = 5.0f;

    private bool indoParaPontoFinal = true;
    [SerializeField] float intervaloDash = 3f;  
    private float tempoDash;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Eva").transform;
        tempoDash = Time.time;
    }

    void Update()
    {
        float distanciaParaJogador = Vector2.Distance(transform.position, jogador.position);

        if (distanciaParaJogador < alcance)
        {
           if(Time.time - tempoDash < intervaloDash)
           {
                Vector2 direcao = (jogador.position - transform.position).normalized;         
                transform.Translate(direcao * velocidade * Time.deltaTime);
           }
           else
           {
                Vector2 direcao = (jogador.position - transform.position).normalized;
                transform.Translate(-direcao * velocidadeDash * Time.deltaTime);
           }
           
        }
        else
        {
            MoveInimigo();
            VerificaLimites();
        }
    }

    void MoveInimigo()
    {
        Vector2 direcao = indoParaPontoFinal ? Vector2.right : Vector2.left;
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    void VerificaLimites()
    {
        if (indoParaPontoFinal && transform.position.x >= pontoFinal.x)
        {
            indoParaPontoFinal = false;
        }
        else if (!indoParaPontoFinal && transform.position.x <= pontoInicial.x)
        {
            indoParaPontoFinal = true;

            if (Vector2.Distance(transform.position, jogador.position) >= alcance)
            {
                transform.position = pontoInicial;
            }
        }
    }
}
