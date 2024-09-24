using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//faz com que a câmera siga o jogador enquanto mantém uma distância fixa (ou "offset") entre a câmera e o jogador.

public class cameraController : MonoBehaviour
{
    // Esta variável pública é usada para armazenar uma referência ao objeto do jogador 
    public GameObject player;

    //O offset é um vetor tridimensional (Vector3) que armazena a diferença entre a posição inicial da câmera e a posição inicial do jogador. Ele garante que a câmera permaneça em uma distância constante do jogador enquanto o segue.
    private Vector3 offset;

    //é um método chamado uma vez, logo no início do ciclo de vida do script 
    void Start()
    {
        //Esta linha calcula a diferença (ou "offset") entre a posição inicial da câmera e a posição inicial do jogador. Isso garante que, ao seguir o jogador, a câmera mantenha sempre a mesma distância inicial.
        offset = transform.position - player.transform.position;    
    }

    //LateUpdate() é um método chamado uma vez por quadro, assim como o Update(), mas ele tem uma diferença importante: LateUpdate() é chamado após todas as outras atualizações de movimento e física.
    void LateUpdate()
    {
        //O resultado dessa linha é que a câmera sempre se reposiciona para a nova posição do jogador, mas mantendo a mesma "distância inicial" (o valor de offset).
        transform.position = player.transform.position + offset; 
    }
}
