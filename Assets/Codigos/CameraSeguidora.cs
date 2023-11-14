using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguidora : MonoBehaviour
{

    #region variavel

    [SerializeField] GameObject alvo;

    [SerializeField] Vector2 distancia;

    [SerializeField] float velocidade;

    Vector2 posição;

    #endregion
    
    void FixedUpdate() 
    {
        posição.x = Mathf.SmoothDamp(transform.position.x, alvo.transform.position.x, ref distancia.x, velocidade); 
        posição.y = Mathf.SmoothDamp(transform.position.y, alvo.transform.position.y, ref distancia.y, velocidade); 
        transform.position = new Vector3(posição.x, posição.y, transform.position.z);
    }
    
}
