using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonMusker : MonoBehaviour
{
    [SerializeField] Transform Jogador;
    [SerializeField] float acaoDistancia = 15f;
    [SerializeField] float distanciaTeleporte = 5f;
    [SerializeField] float intervaloTeleporte = 3f; 

    [SerializeField] GameObject prefab; 

    float timer = 0f;
    private float tempoUltimoTeleporte;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            if(timer >=20f)
            {
                MovimentoMissil();
                timer = 0f;
            }
            
            
        }
        
    }
    void MovimentoTeleporte()
    {
        Vector2 novaPosicao = new Vector2(Jogador.position.x, Jogador.position.y) + (Vector2.up * distanciaTeleporte);
        transform.position = novaPosicao;
    }
    void MovimentoMissil()
    {
        for (int i = 0; i <=5 ; i++)
        {
            prefab.transform.position = transform.position;
            Instantiate(prefab);
        }
        
    }
}
