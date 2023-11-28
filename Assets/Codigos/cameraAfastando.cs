/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAfastando : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float zoomOutAmount = 10.0f; // Quantidade de zoom-out desejada
    public float zoomSpeed = 2.0f; // Velocidade de zoom

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Referência ao jogador não atribuída à câmera!");
            return;
        }

        // Configurar a posição inicial da câmera
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Iniciar o zoom-out
        ZoomOut();
    }

    void Update()
    {
        // Atualizar a posição da câmera para seguir o jogador suavemente
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * zoomSpeed);
    }

    void ZoomOut()
    {
        // Ajustar o campo de visão para simular o zoom-out
        Camera.main.fieldOfView += zoomOutAmount;

        // Se desejar animar o zoom-out suavemente, você pode usar uma abordagem semelhante ao exemplo com o LeanTween
    }

}
*/