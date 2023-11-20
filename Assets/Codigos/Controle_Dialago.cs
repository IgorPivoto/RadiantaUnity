using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controle_Dialago : MonoBehaviour
{
    
    [Header("componentes")]
    [SerializeField] GameObject objetoDialago;
    //[SerializeField] Image perfil;
    [SerializeField] TextMeshProUGUI dialago;
    [SerializeField] TextMeshProUGUI nomePersonagem;

    [Header("configuração")]

    [SerializeField] float velocidadeDeEscrita;
    private string[] sentenca;
    private int index;

    public void Discurso(/*Sprite personagem,*/ string[] txt, string nomeAtor)
    {
        objetoDialago.SetActive(true);
        //perfil.sprite = personagem;
        sentenca = txt;
        nomePersonagem.text = nomeAtor;
        StartCoroutine(TipodeSentenca());
    }
    IEnumerator TipodeSentenca()
    {
        foreach (char letras in sentenca[index].ToCharArray())
        {
            dialago.text += letras;
            yield return new WaitForSeconds(velocidadeDeEscrita);
        }
    }

    public void ProximaFrase()
    {
        if(dialago.text == sentenca[index])
        {
            if(index < sentenca.Length -1)
            {
                index++;
                dialago.text = "";
                StartCoroutine(TipodeSentenca());
            }
            else
            {
                dialago.text = "";
                index =0;
                objetoDialago.SetActive(false);
                FindObjectOfType<Dialago>().PodeFalar();
                
            }
        }
        
    }

}
