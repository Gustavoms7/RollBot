using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;    // Referência ao jogador
    public float speed = 3.0f;  // Velocidade do inimigo
    public float chaseDistance = 10.0f;  // Distância máxima para começar a perseguir o jogador

    private bool isChasing = false;  // Variável para controlar se o inimigo está perseguindo

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseDistance)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}