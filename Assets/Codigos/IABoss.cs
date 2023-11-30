using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class IABoss : MonoBehaviour
{
    [SerializeField] Transform Jogador;
    [SerializeField] float acaoDistancia = 15f;
    [SerializeField] float distanciaTeleporte = 5f;
    [SerializeField] float intervaloTeleporte = 3f; 

    [SerializeField] GameObject prefab; 

    float timer = 0f;
    private float tempoUltimoTeleporte;

    void Start()
    {
        tempoUltimoTeleporte = Time.time;
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        float Distancia = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(Jogador.position.x, Jogador.position.y));


        if (Distancia < acaoDistancia && Time.time - tempoUltimoTeleporte > intervaloTeleporte)
        {
            MovimentoTeleporte();
            tempoUltimoTeleporte = Time.time;
        }
        else if(Distancia < 15)
        {   
            Debug.Log(timer);
            if(timer >=1.5f)
            {
                MovimentoLaser();
                timer = 0f;
            }
            
            
        }
        
        
    }

    void MovimentoTeleporte()
    {
        Vector2 novaPosicao = new Vector2(Jogador.position.x, Jogador.position.y) + (Vector2.up * distanciaTeleporte);
        transform.position = novaPosicao;
    }

    void MovimentoLaser()
    {   


        prefab.transform.position = transform.position;
        Instantiate(prefab);

    }
}