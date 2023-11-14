using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.IK;


public class Eva : MonoBehaviour
{
    
    #region varivavel
    [Header("Configuração de velocidade")]
    [SerializeField] internal float velocidade;
    
    [SerializeField] float dashVelocidade;

    [SerializeField] internal float tempoImpedeDash;
    [SerializeField] float tempoParaAtivarMana = 2f;
    [SerializeField] float manaAtual = 0f;
    [SerializeField] float manaMaxima = 100f;
    private int DashTemp = 1;

    private bool estaPressionandoEspaco = false;
    private float tempoPressionandoEspaco = 0f;

    [SerializeField]
    [Range(0,100)] 
    [Tooltip("Aqui você pode escolher a quantidade de estamina que o player ira usar.")]
    internal int estamina = 100;

    [Header("Configuração de componentes")]
    
    [SerializeField] Rigidbody2D rig;

    [SerializeField] Animator anim;

    [SerializeField] Transform skin;
   
    float velocidadeAtual;
    bool podeDash = true;
    bool podeAtacar = true;
    bool destravaAtaque = false;
    private float tempoEstamina = 0;

    #endregion

    
    void Start()
    {
        //rig = GetComponent<Rigidbody2D>();
        velocidadeAtual = velocidade;
        DontDestroyOnLoad(transform.gameObject);     
    }

    // Update is called once per frame
    void Update()
    {   
        ApertandoMana();
        Movimento();
        Impulso();
        Ataque();
        Morte();
        
    }
    void ApertandoMana()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!estaPressionandoEspaco)
            {
                estaPressionandoEspaco = true;
            }

            // Incrementa o tempo que a tecla está sendo pressionada
            tempoPressionandoEspaco += Time.deltaTime;

            // Verifica se o tempo de pressionar a tecla é maior ou igual ao tempo desejado
            if (tempoPressionandoEspaco >= tempoParaAtivarMana)
            {
                AtivarMana();
            }
        }
        else
        {
            // Se a tecla de espaço não está sendo pressionada, reinicia as variáveis
            estaPressionandoEspaco = false;
            tempoPressionandoEspaco = 0f;
        }
    }
     void AtivarMana()
    {
        // Ativa a mana e reinicia as variáveis
        manaAtual = manaMaxima;
        estaPressionandoEspaco = false;
        tempoPressionandoEspaco = 0f;
        Debug.Log("Mana ativada!");
        DashTemp =4;
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
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f);
        if(movimento.x != 0 || movimento.y != 0)
        {
            if(estamina>=20)
            { 
                if(Input.GetKeyDown(KeyCode.LeftShift) && podeDash)
                {
                    velocidadeAtual = dashVelocidade*DashTemp;
                    estamina -= 20;
                    Invoke("Posdash",0.1f);
                    podeDash = false; 
                    Invoke("HabilitarDash", tempoImpedeDash);
                    DashTemp =1;
                }
            }
        }
        else
        {
            Debug.Log("pode nao meu fi");
        }
        Debug.Log("estou subindo estamina");
        SobeEstamina();
    }


    private void SobeEstamina()
    {   
        Hud hud = gameObject.GetComponent<Hud>();

        Debug.Log("entrei no sobe esramina");
        //Debug.Log(tempoEstamina);
        tempoEstamina += Time.deltaTime;
        if(tempoEstamina >= 2.0f)
        {
            tempoEstamina = 0;
            estamina += 10;
            hud.ControlaBarraEstamina();
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
