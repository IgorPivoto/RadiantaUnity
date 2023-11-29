using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class AnimacaoMoeda : MonoBehaviour
{
    [SerializeField] float amplitude = 0.5f;
    [SerializeField] float velocidade = 1.0f;
    [SerializeField] float velocidadeRotacao = 45f;
    [SerializeField] float velocidadeInclinacao = 30f;

    private Vector3 posicaoInicial;
    private float startTime;
    void Start()
    {
        posicaoInicial = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        AnimacaoDaMoeda();
    }

    void AnimacaoDaMoeda()
    {
        float newY = posicaoInicial.y + amplitude * Mathf.Sin(velocidade * (Time.time - startTime));
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Calcula a inclinação
        float inclinacao = velocidadeInclinacao * Mathf.Sin(velocidadeRotacao * (Time.time - startTime));

        // Aplica a inclinação ao longo do eixo Z
        transform.rotation = Quaternion.Euler(0f, 0f, inclinacao);
    }
}
