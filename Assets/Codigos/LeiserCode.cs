using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiserCode : MonoBehaviour
{
    public float speed; 

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Eva")
        {
            VidaEva eva = FindObjectOfType<VidaEva>();
            eva.vida -= 20;
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Barreira")
        {
            Destroy(gameObject);
        }
    }
}
