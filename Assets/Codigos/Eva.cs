using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UI;

public class Eva : MonoBehaviour
{
    
    #region varivavel
    [Header("Configuração da EVA")]
    [SerializeField] internal float velocidade;
    
    [SerializeField] float dashVelocidade;

    [SerializeField] internal float tempoImpedeDash;

    [SerializeField] Rigidbody2D rig;

    [SerializeField] Animator anim;

    [SerializeField] Transform skin;

    [SerializeField]
    [Range(0,100)] 
    [Tooltip("Aqui você pode escolher a quantidade de estamina que o player ira usar.")]
    internal int estamina = 100;

    float velocidadeAtual;

    bool podeDash = true;
    
    bool podeAtacar = true;

    bool destravaAtaque = false;
    
    

    #endregion

    private float tempoEstamina;
    void Start()
    {
        //rig = GetComponent<Rigidbody2D>();
        velocidadeAtual = velocidade;
        DontDestroyOnLoad(transform.gameObject);
        tempoEstamina = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {   
        Movimento();
        if(estamina>=20){
            Impulso();
        }
        
        Ataque();
        Morte();
        SobeEstamina();
    }

    void Movimento()
    {
        //float movimentoH = Input.GetAxis("Horizontal");
        //float movimentoV = Input.GetAxis("Vertical");
        
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f);     
        movimento.Normalize();

        anim.SetFloat("horizontal",movimento.x);
        anim.SetFloat("vertical",movimento.y);
        anim.SetFloat("velocidade",movimento.magnitude);

        if(movimento != Vector3.zero)
        {
            anim.SetFloat("idle_horizontal",movimento.x);
            anim.SetFloat("Idle_vertical",movimento.y);
        }

        transform.position += movimento * Time.deltaTime * velocidadeAtual;
    }

    void Impulso()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && podeDash)
        {
            velocidadeAtual = dashVelocidade;
            estamina -= 20;
            Invoke("Posdash",0.1f);
            podeDash = false; 
            Invoke("HabilitarDash", tempoImpedeDash);
        }
    }


    private void SobeEstamina()
    {
        Hud hud = gameObject.GetComponent<Hud>();
        float tempoAtual = Time.realtimeSinceStartup;
        float tempoDecorrido = tempoAtual - tempoEstamina;

        if (tempoDecorrido >= 1f)
        {
            tempoEstamina = tempoAtual;
            estamina += 10;
            estamina = Mathf.Clamp(estamina, 0, 100);
            
        }
       
    }

    



    void Posdash()
    {
        velocidadeAtual = velocidade;
    }

    void HabilitarDash()
    {
        podeDash = true;
    }

    void Ataque()
    {
        if(destravaAtaque == true)
        {
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");
            if(Input.GetAxis("Fire1")!=0f&&podeAtacar)
            {
                anim.SetFloat("horizontal",Horizontal);
                anim.SetFloat("vertical",Vertical);
                //skin.GetComponent<Animator>().Play("ataque", -1);
                anim.SetBool("ataque",true);
                Invoke("TravaAtaque",0.5f);
                podeAtacar = false;
                Invoke("TempoImpedeAtaque",1f);
            
                Debug.Log("Ataque");
            }
            else
            {

            }
        }
        
    }
    void TravaAtaque()
    {
        anim.SetBool("ataque",false);
    }

    void TempoImpedeAtaque()
    {
        podeAtacar = true;
    }

    /*void SobeEstamina()
    {
        if(estamina < 100)
        {
            estamina += 10;
        }
    }*/
    

    public void FeedBackDano()
    {
        
        if(GetComponent<VidaEva>().vida > 1)
        {
            anim.SetBool("hit",true);
            Invoke("TravaHit",0.2f);
        }

        else
        {
            Morte();
        }
    }

    void TravaHit(){
        anim.SetBool("hit",false);
    }

    void Morte()
    {
       // float Horizontal = Input.GetAxis("Horizontal");
       // float Vertical = Input.GetAxis("Vertical");
        if(GetComponent<VidaEva>().vida <= 0)
        {
            //anim.SetFloat("homorte",Horizontal);
            //anim.SetFloat("vermorte",Vertical);
            skin.GetComponent<Animator>().Play("morte", -1);
            this.enabled = false;
            
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {   
        if(other.collider.CompareTag("espada"))
        {
            destravaAtaque = true;
            GameObject espada = GameObject.FindGameObjectWithTag("espada");
            Destroy(espada);
        }
        
    }
    
}