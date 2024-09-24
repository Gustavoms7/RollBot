using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class robotControll : MonoBehaviour
{
    public float TurnSpeed = 200.0f;
    public float MaxSpeed = 6.0f;

    
    
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;

    float m_Horizontal;
    float m_Vertical;

    private int m_SpeedRatioHash;
    private bool m_HasSpeedRatio;

    private int count;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public TextMeshProUGUI timeText;  // Exibe o tempo na tela
    private float elapsedTime;        // Armazena o tempo decorrido
    private bool isGameActive = true; // Verifica se o jogo ainda está rodando

    public GameOverManager gameOverManager;  // Referência ao script GameOverManager
    public GameWinManager gameWinManager;  // Referência ao script GameOverManager
    
    [SerializeField] private AudioSource audioSource;

    public AudioClip energy;
    

    void Awake()
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        // Add this line to get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();

        m_SpeedRatioHash = Animator.StringToHash("SpeedRatio");
        m_HasSpeedRatio = m_Animator.parameters.Any(parameter => parameter.nameHash == m_SpeedRatioHash);
    }

    void SetCountText() 
    {
        countText.text =  "Energia: " + count.ToString();
        if (count >= 10)
        {
            gameWinManager.ShowGameWin();
            
        }
    }

    void FixedUpdate()
    {
        // Captura de movimento
        m_Horizontal = Input.GetAxis("Horizontal");
        m_Vertical = Input.GetAxis("Vertical");

        float speed = MaxSpeed * m_Vertical;
        

        bool isWalking = m_Vertical > 0.1f;
        m_Animator.SetBool("IsWalking", isWalking);
        m_Animator.SetFloat("Speed", m_Vertical * speed);

        // Rotação do jogador
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, m_Horizontal * TurnSpeed * Time.deltaTime, 0));
        m_Rigidbody.MoveRotation(transform.rotation * deltaRotation);

        // Movimentação para frente
        if (!m_Animator.hasRootMotion)
        {
            m_Rigidbody.MovePosition(m_Rigidbody.position + transform.forward * speed * Time.deltaTime);
        }

        if (m_HasSpeedRatio)
        {
            m_Animator.SetFloat(m_SpeedRatioHash, Mathf.Abs(speed / MaxSpeed));
        }

        if (isGameActive)
        {
            elapsedTime += Time.deltaTime;  // Incrementa o tempo a cada quadro
            UpdateTimeText();               // Atualiza o texto na tela
        }


    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + transform.forward * m_Animator.deltaPosition.magnitude);
    }

    void UpdateTimeText()
    {
        // Formata o tempo em minutos e segundos
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100F) % 100F);
        
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }


    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto coletado tem a tag "PickUp"
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();

            audioSource.PlayOneShot(energy);
        }

         


        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Detecta a colisão com o inimigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOverManager.ShowGameOver();  // Mostra a tela de derrota
        }
    }
}
