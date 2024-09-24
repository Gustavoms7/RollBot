using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class playerController : MonoBehaviour
{   
    //Declara uma variável privada chamada rb, que vai armazenar uma referência ao componente Rigidbody do objeto ao qual este script está anexado.
    private Rigidbody rb;

    //são responsáveis por capturar e armazenar as coordenadas de movimento do jogador nos eixos horizontal e vertical.
    private float movementX;
    private float movementY;

    //Variavel que armazena o numero de pickUps coletado
    private int count;

    //A variável speed está declarada como pública, o que significa que ela aparecerá no Inspector do Unity, permitindo que você defina o valor diretamente na interface do Editor.
    public float speed = 0; 
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public TextMeshProUGUI timeText;  // Exibe o tempo na tela
    private float elapsedTime;        // Armazena o tempo decorrido
    private bool isGameActive = true; // Verifica se o jogo ainda está rodando



    


    // O método Start é executado uma vez, logo no início do ciclo de vida do GameObject.
    void Start()
    {

        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        //Aqui você está atribuindo o Rigidbody do próprio GameObject a essa variável rb usando GetComponent<Rigidbody>(). Isso é importante porque permitirá aplicar física à esfera.
        rb = GetComponent <Rigidbody>(); 

    }

    //Esse método é chamado quando ocorre uma entrada do jogador (no caso, provavelmente um movimento). O argumento InputValue contém os dados da entrada.
    void OnMove(InputValue movementValue)
    {
        //Aqui, a entrada é convertida em um vetor bidimensional (Vector2). O vetor tem dois componentes: x e y. Isso é comum quando estamos lidando com controles de movimento em duas direções (eixos horizontais e verticais).
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        //epresenta o movimento no eixo horizontal
        movementX = movementVector.x;
        //representa o movimento no eixo vertical
        movementY = movementVector.y;

        //movementX e movementY são atualizados toda vez que o jogador move o controle (ou pressiona uma tecla) e são usados depois para criar um movimento no espaço 3D.

    }

    void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 4)
       {
           winTextObject.SetActive(true);
       }
   }

    //Aqui, a entrada é convertida em um vetor bidimensional (Vector2). O vetor tem dois componentes: x e y. Isso é comum quando estamos lidando com controles de movimento em duas direções (eixos horizontais e verticais).
    private void FixedUpdate() 
   {
        //Aqui, você está criando um vetor tridimensional (Vector3 movement) com três componentes.combina o movimento em duas dimensões (X e Z) para mover a esfera no plano. O eixo Y é zero, pois estamos lidando com movimento horizontal, e não vertical.
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

        //aplica uma força ao componente Rigidbody (que está associado à esfera) com base no Vector3 movement que você criou.
        rb.AddForce(movement*speed);
   }

    //void OnTriggerEnter(Collider other): Este é o método que será chamado automaticamente pelo Unity quando o objeto que contém esse script colidir com outro objeto que tenha um "Trigger" ativado no seu colisor.
    //Collider other: Esse parâmetro other representa o objeto com o qual o jogador colidiu. Ele fornece todas as informações sobre o objeto que entrou no colisor .
    void OnTriggerEnter(Collider other) 
   {
        //other.gameObject.SetActive(false): Esta linha de código desativa o GameObject com o qual o jogador colidiu. Aqui está o que acontece:
        //verifica se a tag é a do pickUp
        if (other.gameObject.CompareTag("PickUp")) 
       {
           other.gameObject.SetActive(false);
           count = count + 1;
           SetCountText();
       }
        //(É o objeto com o qual o jogador colidiu).(Refere-se ao próprio objeto de jogo).(Este método desativa o objeto, fazendo com que ele desapareça do jogo. Quando um objeto é desativado, ele não aparece mais na cena e também não executa seus scripts.)
   }

    

}
