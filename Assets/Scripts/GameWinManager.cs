using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinManager : MonoBehaviour
{
    public GameObject gameWinPanel;  // Referência ao painel de derrota

    // Método para ativar o painel de derrota
    public void ShowGameWin()
    {
        gameWinPanel.SetActive(true);
        Time.timeScale = 0;  // Pausar o jogo
    }

    // Método para reiniciar o jogo
    public void RestartGame()
    {
        Time.timeScale = 1;  // Retornar o tempo normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Recarrega a cena atual
    }
}
