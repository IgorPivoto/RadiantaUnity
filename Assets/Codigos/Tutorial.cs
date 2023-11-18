using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    

    [SerializeField] Renderer imagemTutorial;
    [SerializeField] private float velocidadeVariacao = 0.5f;
    [SerializeField] bool tutorialCorreDaIa;
    private bool aumentando = true;

    [SerializeField] Renderer imagemTutorialCorrida1;
    [SerializeField] Renderer imagemTutorialCorrida2;
    [SerializeField] Renderer imagemTutorialCorrida3;
    [SerializeField] Renderer imagemTutorialCorrida4;

    

    // Start is called before the first frame update
    void Start()
    {   
        
        imagemTutorial = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        Renascer renascer = GetComponent<Renascer>();
        if(tutorialCorreDaIa == false)
        {
            TransparenteParaVisivel();
        }
        else if(tutorialCorreDaIa == true && renascer.numeroDeRespawn >=5)
        {
            TutorialIA();
        }
        
    }

    void TransparenteParaVisivel()
    {
        Material material = imagemTutorial.material;

        float alpha = material.color.a;

        if (aumentando)
        {
            alpha += velocidadeVariacao * Time.deltaTime;
            if (alpha >= 1.0f)
            {
                alpha = 1.0f;
                aumentando = false;
            }
        }
        else
        {
            alpha -= velocidadeVariacao * Time.deltaTime;
            if (alpha <= 0.0f)
            {
                alpha = 0.0f;
                aumentando = true;
            }
        }

        material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
    }

    void TutorialIA()
    {
        Material material = imagemTutorial.material;

        float alpha = material.color.a;

        if (aumentando)
        {
            alpha += velocidadeVariacao * Time.deltaTime;
            if (alpha >= 1.0f)
            {
                alpha = 1.0f;
                aumentando = false;
            }
        }
        else
        {
            alpha -= velocidadeVariacao * Time.deltaTime;
            if (alpha <= 0.0f)
            {
                alpha = 0.0f;
                aumentando = true;
            }
        }

        material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
    }
            
}

