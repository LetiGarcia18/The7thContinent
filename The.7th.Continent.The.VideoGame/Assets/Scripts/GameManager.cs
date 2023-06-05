using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Character> characters;
    public static bool isFirstTimeLevel1 = true;

    /// <summary>
    /// Esta funcion hace que, si en la escena no existe la instancia al objeto, hace que la haga igual así misma.
    /// Y con el método DontDestroyOnLoad podremos pasarlo entre escenas, y si ya existe una, que se destruya
    /// </summary>
    public void Awake()
    {
        if(GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
