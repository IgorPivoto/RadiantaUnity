using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialago : MonoBehaviour
{
    /*
    #region variavel

    [SerializeField] string[] npcDialago;

    [SerializeField] int dialagoIndex;

    [SerializeField] GameObject painelDialago;

    [SerializeField] Text dialago;

    [SerializeField] Text nomeNpc;

    [SerializeField] Image imageNpc;

    [SerializeField] Sprite spriteNpc;

    [SerializeField] bool podeFalar;

    [SerializeField] bool podeIniciarDialago;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        painelDialago.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && podeFalar)
        {
            if(!podeIniciarDialago)
            {
                FindObjectOfType<Eva>().velocidade = 0f;
                IniciaDialago();
            }
            else if (dialago.text == npcDialago[dialagoIndex])
            {
                ProximoDialago();
            }

        }
    }

    void ProximoDialago()
    {
        dialagoIndex++;
        if(dialagoIndex <= npcDialago.Length)
        {
            StartCoroutine(MostrarDialago());
        }
        else
        {
            painelDialago.SetActive(false);
            podeIniciarDialago = false;
            dialagoIndex = 0;
            FindObjectOfType<Eva>().velocidade = 6.5f;
            
        }
    }

    void IniciaDialago()
    {
        nomeNpc.text = "carlos Maia";
        imageNpc.sprite = spriteNpc;
        podeIniciarDialago = true;
        dialagoIndex = 0;
        painelDialago.SetActive(true);
        StartCoroutine(MostrarDialago());
    }
    IEnumerator MostrarDialago()
    {
        dialago.text = "";
        foreach (char letras in npcDialago[dialagoIndex])
        {
            dialago.text += letras;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Eva"))
        {
            podeFalar = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Eva"))
        {
            podeFalar = false;
        }
        
    }*/
}
