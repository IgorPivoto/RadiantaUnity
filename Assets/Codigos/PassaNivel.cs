using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PassaNivel : MonoBehaviour
{

    [SerializeField] string nomeLevel;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Eva"))
        {
            Debug.Log("passando para a fase " +nomeLevel);
            SceneManager.LoadScene(nomeLevel);
        }
        
    }

}
