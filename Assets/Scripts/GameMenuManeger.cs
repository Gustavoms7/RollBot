using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuManeger : MonoBehaviour
{
    public GameObject menuPanel;  // Referência ao painel do menu

    void Start()
    {
        // O menu é mostrado no início do jogo
        menuPanel.SetActive(true);

        // Pausa o jogo no início
        Time.timeScale = 0f;  // Pausar o tempo do jogo
    }

    // Método chamado quando o jogador clica em "Play"
    public void StartGame()
    {
        menuPanel.SetActive(false);  // Oculta o menu
        Time.timeScale = 1f;  // Retorna o tempo normal do jogo
    }
}
