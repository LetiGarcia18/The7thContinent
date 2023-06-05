using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Class representing the in-game pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Represents the pause button.
    /// </summary>
    public GameObject pauseButton;
    /// <summary>
    /// Represents pause menu.
    /// </summary>
    public GameObject pauseMenu;
    /// <summary>
    /// It represents that the pause menu is not currently active.
    /// </summary>
    private bool pausedGame = false;

    /// <summary>
    /// It is verified that if the Escape key is pressed, and the pause menu is active, the Resume function is called. 
    /// If not, then the Pause function is called.
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame) 
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// This function disables the pause button and activates the pause menu.
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    /// <summary>
    /// This function activates the pause button and deactivates the pause menu.
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    /// <summary>
    /// Function that reloads the scene.
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    /// <summary>
    /// Function that allows us to exit the game.
    /// </summary>
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
