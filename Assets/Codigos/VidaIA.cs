using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaIA : MonoBehaviour
{
    
    [Range(0,200)] 
    [SerializeField] 
    int vidaIA;

    [SerializeField] Animator animacao;
    float timer = 0f;

    void Update() 
    {
        
        Morte();
    }

    internal void Vida(int dano)
    {
        vidaIA -= dano;
    }
    void Morte()
    {
        if(vidaIA <= 0)
        {
            timer += Time.deltaTime;
            animacao.SetBool("Morte",true);
            if(timer >= 1f)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
