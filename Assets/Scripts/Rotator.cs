using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //No caso deste script, não há nada que precise ser inicializado no início. O que o script faz é aplicar uma rotação contínua ao objeto, e como essa rotação precisa acontecer a cada quadro, toda a lógica necessária está dentro do método Update().

    // O método Update() é chamado uma vez por quadro (frame), ou seja, ele é executado continuamente enquanto o jogo está rodando.
    void Update()
    {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }
}
