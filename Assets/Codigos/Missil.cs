using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class Missil : MonoBehaviour
{

    private Transform jogador;
    [SerializeField] float velocidade = 10.0f;
    [SerializeField] int danoMissil = 5;
    float timer = 0f;
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Eva").transform;
    }

    void Update()
    {   
        LancaMissil();
        timer += Time.deltaTime;
        
    }
    void LancaMissil()
    {
        
        Vector2 direcao = (jogador.position - transform.position).normalized;         
        transform.Translate(direcao * velocidade * Time.deltaTime);
        
        float angle = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(velocidade <= 100 && timer >=1f)
        {   
            timer = 0f;
            velocidade += 10;
        }
    }
     void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("cenario"))
        {
            Destroy(gameObject);
        }    
        if(other.collider.CompareTag("Eva"))
        {
            VidaEva vidaEva = FindObjectOfType<VidaEva>();
            vidaEva.RemoveVida(danoMissil);
            Destroy(gameObject);
        }
    }

    
}
