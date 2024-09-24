using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;  // Referência ao painel de derrota
    public GameObject menuPanel;      // Referência ao painel de menu inicial

    // Método para ativar o painel de derrota
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;  // Pausar o jogo
    }

    // Método para reiniciar o jogo
    public void RestartGame()
    {
        Time.timeScale = 1;  // Retornar o tempo normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Recarrega a cena atual
        
    }

}
