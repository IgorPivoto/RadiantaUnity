using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{

    #region variavel
    [Header("Configuração do hud para vida")]
    [SerializeField] Sprite hudMorto;
    [SerializeField] Sprite hud20;
    [SerializeField] Sprite hud40;
    [SerializeField] Sprite hud60;
    [SerializeField] Sprite hud80;
    [SerializeField] Sprite hud100;
    [SerializeField] Image hud;

    [Header("Configuração do hud para estamina")]
    [SerializeField] Sprite hudDash0;
    [SerializeField] Sprite hudDash10;
    [SerializeField] Sprite hudDash20;
    [SerializeField] Sprite hudDash30;
    [SerializeField] Sprite hudDash40;
    [SerializeField] Sprite hudDash50;
    [SerializeField] Sprite hudDash60;
    [SerializeField] Sprite hudDash70;
    [SerializeField] Sprite hudDash80;
    [SerializeField] Sprite hudDash90;
    [SerializeField] Sprite hudDash100;
    [SerializeField] Image hudDash;

    [SerializeField] Image hudBarraEstamina;


    
    #endregion
    


    

    void Update()
    {
        ControlaHudVida();
        ControleHudTempoDash();
        ControlaBarraEstamina();
    }
     


    void ControlaHudVida()
    {
        VidaEva vidaEva = gameObject.GetComponent<VidaEva>();
        //VidaEva vidaEva = GetComponent<VidaEva>();
        if(vidaEva.vida <= 0)
        {
            hud.sprite = hudMorto;
        }
        else if(vidaEva.vida <=20)
        {
            hud.sprite = hud20;
        }
        else if(vidaEva.vida <= 40)
        {
            hud.sprite = hud40;
        }
        else if(vidaEva.vida <= 60)
        {
            hud.sprite = hud60;
        }
        else if(vidaEva.vida <= 80)
        {
            hud.sprite = hud80;
        }
        else if(vidaEva.vida <= 100)
        {
            hud.sprite = hud100;
        }

    }

    void ControleHudTempoDash()
    {
        Eva evaEstamina = gameObject.GetComponent<Eva>();

        if(evaEstamina.estamina <= 0)
        {
            hudDash.sprite = hudDash0;
        }
        else if(evaEstamina.estamina <= 10)
        {
            hudDash.sprite = hudDash10;
        }
        else if(evaEstamina.estamina <= 20)
        {
            hudDash.sprite = hudDash20;
        }
        else if(evaEstamina.estamina <= 30)
        {
            hudDash.sprite = hudDash30;
        }
        else if(evaEstamina.estamina <= 40)
        {
            hudDash.sprite = hudDash40;
        }
        else if(evaEstamina.estamina <= 50)
        {
            hudDash.sprite = hudDash50;
        }
        else if(evaEstamina.estamina <= 60)
        {
            hudDash.sprite = hudDash60;
        }
        else if(evaEstamina.estamina <= 70)
        {
            hudDash.sprite = hudDash70;
        }
        else if(evaEstamina.estamina <= 80)
        {
            hudDash.sprite = hudDash80;
        }
        else if(evaEstamina.estamina <= 90)
        {
            hudDash.sprite = hudDash90;
        }
        else if(evaEstamina.estamina <= 100)
        {
            hudDash.sprite = hudDash100;
        }
    
    }
    internal void ControlaBarraEstamina()
    {
        Eva evaAtributos = gameObject.GetComponent<Eva>();
        
        if(evaAtributos.estamina < 100)
        {   
            //evaAtributos.tempoEstamina += Time.deltaTime;
            float percentualCompleto = evaAtributos.tempoEstamina / 2;
            hudBarraEstamina.fillAmount = percentualCompleto;
            if(percentualCompleto >= 1.0f)
            {
                evaAtributos.tempoEstamina = 0;
            }

        }


        /*if(evaAtributos.estamina < 100)
        {   
            tempoBarraEStamina += Time.deltaTime;
            float percentualCompleto = tempoBarraEStamina / 2;
            hudBarraEstamina.fillAmount = percentualCompleto;
            if(percentualCompleto >= 1.0f)
            {
                tempoBarraEStamina = 0;
            }

        }*/
     
    }


    
}
