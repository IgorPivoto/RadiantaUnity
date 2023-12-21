using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneY : MonoBehaviour
{
    public float velocidade = 5f;
    private bool movendoParaCima = true;

    void Update()
    {
        if (movendoParaCima)
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cenario"))
        {
            movendoParaCima = !movendoParaCima;
            velocidade += 0.2f;
        }
    }
}
