using UnityEngine;

public class Controle_Dialogo_Personagem : MonoBehaviour
{
    [SerializeField] private Dialogo dialogo;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float raio;

    private bool naArea;
    private bool falando = false;
    private Controle_Dialogo scriptControleDialogo;

    private void Start()
    {
        scriptControleDialogo = GetComponent<Controle_Dialogo>();
    }

    private void Update()
    {
        if (scriptControleDialogo.TravaCodigoDialago == false)
        {
            InteraçãoDialago();

            if (Input.GetKeyDown(KeyCode.T) && naArea && !falando)
            {
                scriptControleDialogo.IniciarDialogo(dialogo.textoDialago, dialogo.nomeAtorDialago, this);
                falando = true;
            }
        }
    }

    private void InteraçãoDialago()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, raio, playerLayer);

        if (hit != null)
        {
            naArea = true;
        }
        else
        {
            naArea = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, raio);
    }

    internal void PodeFalar()
    {
        falando = false;
        Debug.Log("Estou podendo falar");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Eva"))
        {
            scriptControleDialogo.TravaCodigoDialago = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Eva"))
        {
            scriptControleDialogo.TravaCodigoDialago = true;
        }
    }
}
