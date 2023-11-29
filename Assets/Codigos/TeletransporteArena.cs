using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransporteArena : MonoBehaviour
{
    [SerializeField] Transform teletransporteEntrada;
    [SerializeField] Transform teletransporteSaida;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Eva"))
        {
            Debug.Log("Pressione 'T' para teleportar");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.T) && other.CompareTag("Eva"))
        {
            Teleportar(other.gameObject);
        }
    }

    void Teleportar(GameObject objeto)
    {
        if (teletransporteEntrada != null && teletransporteSaida != null)
        {
            objeto.transform.position = teletransporteSaida.position;
        }
        else
        {
            Debug.LogError("Os pontos de teletransporte não foram atribuídos.");
        }
    }
}
