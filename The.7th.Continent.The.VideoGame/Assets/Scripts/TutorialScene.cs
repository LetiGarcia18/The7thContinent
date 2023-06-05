using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the tutorial scene behavior.
/// </summary>
public class TutorialScene : MonoBehaviour
{
    /// <summary>
    /// The main camera used in the scene.
    /// </summary>
    public Camera mainCamera;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    void Start()
    {
        if (GameManager.isFirstTimeLevel1)
        {
            GameManager.isFirstTimeLevel1 = false;
        }
        else
        {
            mainCamera.enabled = false;

            StartCoroutine(LoadLevel1Async());
        }
    }

    /// <summary>
    /// Loads the Level1 scene asynchronously.
    /// </summary>
    IEnumerator LoadLevel1Async()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("CharacterStoryP1", LoadSceneMode.Additive);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(gameObject.scene);

        mainCamera.enabled = true;
    }
}
