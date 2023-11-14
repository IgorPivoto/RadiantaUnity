using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MataIa : MonoBehaviour
{

    [SerializeField] GameObject ia;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Eva"))
        {
            Destroy(ia);
        }
    }
}
