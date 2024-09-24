using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCapsule : MonoBehaviour
{
    public float speed = 3.0f;               // Velocidade do inimigo
    private Vector3 moveDirection = Vector3.left;  // Direção inicial do movimento (movendo para a direita)

    void Update()
    {
        // Mover o inimigo apenas no eixo X
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    // Método que será chamado quando o inimigo colidir com uma parede
    void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto que o inimigo colidiu tem a tag "Wall"
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Inverte a direção do inimigo no eixo X
            moveDirection = -moveDirection;
        }
    }
}
