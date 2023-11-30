using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABoss : MonoBehaviour
{
    [SerializeField] Transform Jogador;
    [SerializeField] float acaoDistancia = 15f;
    [SerializeField] float distanciaTeleporte = 5f;
    [SerializeField] float intervaloTeleporte = 3f; 

    [SerializeField] GameObject prefab; 
    private float tempoUltimoTeleporte;

    void Start()
    {
        tempoUltimoTeleporte = Time.time;
    }

    void Update()
    {
        float Distancia = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(Jogador.position.x, Jogador.position.y));


        if (Distancia < acaoDistancia && Time.time - tempoUltimoTeleporte > intervaloTeleporte)
        {
            MovimentoTeleporte();
            tempoUltimoTeleporte = Time.time;
        }
        else
        {
            MovimentoLaser();
        }
    }

    void MovimentoTeleporte()
    {
        Vector2 novaPosicao = new Vector2(Jogador.position.x, Jogador.position.y) + (Vector2.up * distanciaTeleporte);
        transform.position = novaPosicao;
    }

    void MovimentoLaser()
    {
        Instantiate(prefab);

    }
}