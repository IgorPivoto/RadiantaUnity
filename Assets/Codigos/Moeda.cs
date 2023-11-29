using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
  
    int valor = 25;
    private Transform jogador;
    public float velocidade = 2.0f;
    public float alcance = 5.0f;
    float amplitude = 3.0f;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Eva").transform;
    }

    void Update()
    {

        float oscilacao = Mathf.Sin(Time.time) * amplitude;
        MoverParaJogador();
    }

    void MoverParaJogador()
    {
        float distanciaParaJogador = Vector2.Distance(transform.position, jogador.position);

        if (distanciaParaJogador < alcance)
        {
            Vector2 direcao = (jogador.position - transform.position).normalized;
            transform.Translate(direcao * velocidade * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Eva"))
        {
            Destroy(gameObject);

            Eva eva = FindObjectOfType<Eva>();

            if (eva != null)
            {
                eva.AdicionarValorMoeda(valor);
            }
        }
    }
}

