using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroll : MonoBehaviour
{
    /// <summary>
    ///  Determines the speed at which the text object scrolls downwards.
    /// </summary>
    public float scrollSpeed = 10f;
    /// <summary>
    /// Specifies the duration of the fade-out effect before loading the main menu scene.
    /// </summary>
    public float fadeDuration = 1.0f;

    /// <summary>
    /// This function is called when the script starts. 
    /// </summary>
    void Start()
    {
        Invoke("LoadMainMenu", 80f); 
    }

    /// <summary>
    ///  This function starts the coroutine FadeOutAndLoadScene, which performs the fade-out effect and loads the main menu scene.
    /// </summary>
    void LoadMainMenu()
    {
        StartCoroutine(FadeOutAndLoadScene()); 
    }

    /// <summary>
    ///  This function is called every frame. It moves the text object downwards by translating its position using Translate.
    /// </summary>
    void Update()
    {
        
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }

    /// <summary>
    ///  This coroutine gradually fades the screen to black over a specified duration. It uses a while loop and Mathf.Lerp to calculate the alpha 
    ///  value for the fade effect. Inside the loop, you can implement the fade effect by adjusting the alpha value of the background color or 
    ///  applying a fullscreen effect. After the fade effect is complete, it loads the main menu scene using SceneManager.LoadScene
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOutAndLoadScene()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 10f, elapsedTime / fadeDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("StartMenu");
    }
}
