using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{   

    public GameObject pausePanel;
    private bool isPaused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;       // Freeze the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;       // Resume the game
        isPaused = false;
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void MenuGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}
