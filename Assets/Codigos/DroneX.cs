using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneX : MonoBehaviour
{
public float velocidade = 5f; 
    private bool movendoParaFrente = true;
    void Update()
    {
        if (movendoParaFrente)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cenario"))
        {
            movendoParaFrente = !movendoParaFrente;
            velocidade += 0.2f;
        }
    }
}
