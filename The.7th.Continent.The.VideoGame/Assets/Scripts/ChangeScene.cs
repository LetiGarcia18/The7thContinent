using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that allows switching between scenes
/// </summary>
public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// Class that causes the scene to change to scene 1
    /// </summary>
    public void ChangeScene1()
    {
        SceneManager.LoadScene("Level1");
    }

    /// <summary>
    /// Class that causes the scene to change to scene 2
    /// </summary>
    public void ChangeScene2()
    {
        SceneManager.LoadScene("Level2");
    }

    /// <summary>
    /// Class that causes the scene to change to scene 3
    /// </summary>
    public void ChangeScene3()
    {
        SceneManager.LoadScene("Level3");
    }

    /// <summary>
    /// Class that causes the scene to change to scene 4
    /// </summary>
    public void ChangeScene4()
    {
        SceneManager.LoadScene("Level4");
    }

    /// <summary>
    /// Class that causes the scene to change to start menu
    /// </summary>
    public void ChangeStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    /// <summary>
    /// Class that causes the scene to change to mini game menu scene
    /// </summary>
    public void ChangeMiniGameMenu()
    {
        SceneManager.LoadScene("MiniGamesMenu");
    }

    /// <summary>
    /// Class that causes the scene to change to mini game pingpong scene
    public void MiniGamePingPong()
    {
        SceneManager.LoadScene("MiniGamePingPong");
    }

    /// <summary>
    /// Class that causes the scene to change to mini game cards scene
    /// </summary>
    public void MiniGameCards()
    {
        SceneManager.LoadScene("MiniGameCards");
    }

    /// <summary>
    /// Class that causes the scene to change to choose your player scene
    /// </summary>
    public void ChooseYourPlayerScene()
    {
        SceneManager.LoadScene("ChooseYourPlayer");
    }

    /// <summary>
    /// Class that causes the scene to change to express tutorial
    /// </summary>
    public void ExpressTutorial()
    {
        SceneManager.LoadScene("ExpressTutorial");
    }

    /// <summary>
    /// Class that causes the scene to change to character story scene 1
    /// </summary>
    public void CharacterStoryP1Scene()
    {
        SceneManager.LoadScene("CharacterStoryP1");
    }

    /// <summary>
    /// Class that causes the scene to change to character story scene 2
    /// </summary>
    public void CharacterStoryP2Scene()
    {
        SceneManager.LoadScene("CharacterStoryP2");
    }

    /// <summary>
    /// Class that causes the scene to change to character story scene 3
    /// </summary>
    public void CharacterStoryP3Scene()
    {
        SceneManager.LoadScene("CharacterStoryP3");
    }

    /// <summary>
    /// Class that causes the scene to change to character story scene 4
    /// </summary>
    public void CharacterStoryP4Scene()
    {
        SceneManager.LoadScene("CharacterStoryP4");
    }

    /// <summary>
    /// Class that causes the scene to change to character story scene 5
    /// </summary>
    public void CharacterStoryP5Scene()
    {
        SceneManager.LoadScene("CharacterStoryP5");
    }

    /// <summary>
    /// Class that causes the scene to change to character story scene 6
    /// </summary>
    public void CharacterStoryP6Scene()
    {
        SceneManager.LoadScene("CharacterStoryP6");
    }

    /// <summary>
    /// Class that causes the scene to change to character story scene 7
    /// </summary>
    public void CharacterStoryP7Scene()
    {
        SceneManager.LoadScene("CharacterStoryP7");
    }

    /// <summary>
    /// Class that causes the scene to change to character story scene 8
    /// </summary>
    public void CharacterStoryP8Scene()
    {
        SceneManager.LoadScene("CharacterStoryP8");
    }

    /// <summary>
    /// Class that causes the scene to change to black scene 
    /// </summary>
    public void Black8Scene()
    {
        SceneManager.LoadScene("BlackScene");
    }

    /// <summary>
    /// Class that causes the scene to change to submarine scene 1
    /// </summary>
    public void SubmarineSceneP1()
    {
        SceneManager.LoadScene("SubmarineSceneP1");
    }

    /// <summary>
    /// Class that causes the scene to change to submarine scene 2
    /// </summary>
    public void SubmarineSceneP2()
    {
        SceneManager.LoadScene("SubmarineSceneP2");
    }

    /// <summary>
    /// Class that causes the scene to change to user manual scene 1
    /// </summary>
    public void UserManualP1()
    {
        SceneManager.LoadScene("UserManualP1");
    }

    /// <summary>
    /// Class that causes the scene to change to user manual scene 2
    /// </summary>
    public void UserManualP2()
    {
        SceneManager.LoadScene("UserManualP2");
    }

    /// <summary>
    /// Class that causes the scene to change to user manual scene 3
    /// </summary>
    public void UserManualP3()
    {
        SceneManager.LoadScene("UserManualP3");
    }

    /// <summary>
    /// Class that causes the scene to change to user manual scene 4
    /// </summary>
    public void UserManualP4()
    {
        SceneManager.LoadScene("UserManualP4");
    }

    /// <summary>
    /// Class that causes the scene to change to user manual scene 5
    /// </summary>
    public void UserManualP5()
    {
        SceneManager.LoadScene("UserManualP5");
    }

    /// <summary>
    /// Class that causes the scene to change to user manual scene 6
    /// </summary>
    public void UserManualP6()
    {
        SceneManager.LoadScene("UserManualP6");
    }

    /// <summary>
    /// Class that causes the scene to change to user manual scene 7
    /// </summary>
    public void UserManualP7()
    {
        SceneManager.LoadScene("UserManualP7");
    }

    /// <summary>
    /// Class that causes the scene to change to survive the lava enemy scene
    /// </summary>
    public void SurviveTheLavaEnemy()
    {
        SceneManager.LoadScene("SurviveTheLavaEnemy");
    }

    /// <summary>
    /// Class that causes the scene to change to the end scene
    /// </summary>
    public void TheEnd()
    {
        SceneManager.LoadScene("TheEnd");
    }

    /// <summary>
    /// Class that causes the scene to change to the credits scene
    /// </summary>
    public void CreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }

    /// <summary>
    /// Class that makes you quit the game
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
