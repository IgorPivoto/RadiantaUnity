using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControle : MonoBehaviour
{
    [SerializeField] private AudioSource faseAudio;



    public void TocarFase()
    {
        faseAudio.Play();
    }

    public void PararFase()
    {
        faseAudio.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Eva"))
        {
            TocarFase();
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Eva"))
        {
            PararFase();
        }
    }
}
