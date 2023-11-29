using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    
    internal void DropdeModeda()
    {
        GameObject prefab = Instantiate(Prefab, transform.position, transform.rotation);
        
    }
}
