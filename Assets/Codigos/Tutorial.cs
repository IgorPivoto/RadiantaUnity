using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    
    
    [SerializeField] Renderer imagemTutorial;
    
    [SerializeField] private float velocidadeVariacao = 0.5f;
    [SerializeField] bool tutorialCorreDaIa = false;
    private bool aumentando = true;

    

    

    // Start is called before the first frame update
    void Start()
    {   
        
        imagemTutorial = GetComponent<SpriteRenderer>();
        if (imagemTutorial == null)
    {
        Debug.LogError("O componente SpriteRenderer não foi encontrado no GameObject.", this);
    }

        
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        Renascer renascer = GetComponent<Renascer>();
        
        if(tutorialCorreDaIa == false)
        {
            TransparenteParaVisivel();
            Debug.Log("if");
        }
        else if(tutorialCorreDaIa == true && renascer != null && renascer.numeroDeRespawn >=5)
        {   
            imagemTutorial.enabled = true;
            TransparenteParaVisivel();
            
            Debug.Log("elseif");
        }
        else
        {
            imagemTutorial.enabled = false;
            Debug.Log("else");
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

 
            
}

