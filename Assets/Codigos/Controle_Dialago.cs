using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Controle_Dialago : MonoBehaviour
{
    
    [Header("componentes")]
    [SerializeField] internal GameObject objetoDialago;
    [SerializeField] internal TextMeshProUGUI dialago;
    [SerializeField] internal TextMeshProUGUI nomePersonagem;

    [Header("configuração")]
    [SerializeField] float velocidadeDeEscrita;
    private string[] sentenca;
    private int index;
    //private Dialago dialagoCode;
    public string[] SentencaParam => sentenca;
    public string NomeAtorParam => nomePersonagem.text;

    public void Discurso(string[] txt, string nomeAtor)
    {
        objetoDialago.SetActive(true);
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
                Debug.Log("comecei a falar");
                index++;
                dialago.text = "";
                StartCoroutine(TipodeSentenca());
            }
            else
            {
                dialago.text = "";
                index =0;
                FindObjectOfType<Dialago>().PodeFalar();
                objetoDialago.SetActive(false);
                Debug.Log("parei de falar");
            }
        }
        
    }

}
