using System.Collections;
using UnityEngine;

public class Controle_Dialogo : MonoBehaviour
{
    [SerializeField] private bool travaCodigoDialago = true;

    public bool TravaCodigoDialago
    {
        get { return travaCodigoDialago; }
        set { travaCodigoDialago = value; }
    }

    public void IniciarDialogo(string[] textoDialago, string nomeAtorDialago, Controle_Dialogo_Personagem controlePersonagem)
    {
        StartCoroutine(ExibirDialogo(textoDialago, nomeAtorDialago, controlePersonagem));
    }

    IEnumerator ExibirDialogo(string[] textoDialago, string nomeAtorDialago, Controle_Dialogo_Personagem controlePersonagem)
    {
        // Implemente a lógica de exibição de diálogo, por exemplo, usando caixas de texto, etc.
        Debug.Log(nomeAtorDialago + ": " + textoDialago[0]);

        yield return new WaitForSeconds(3);  // Espera 3 segundos (ajuste conforme necessário)

        // Depois que o diálogo é exibido, permita que o personagem possa falar novamente
        controlePersonagem.PodeFalar();
    }
}
