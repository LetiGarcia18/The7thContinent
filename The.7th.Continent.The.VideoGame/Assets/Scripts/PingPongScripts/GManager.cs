using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// This script manages the game state and scoring.
/// </summary>
public class GManager : MonoBehaviour
{
    /// <summary>
    /// Text component for displaying player 1's score
    /// </summary>
    [SerializeField] private TMP_Text paddle1ScoreText;
    /// <summary>
    /// Text component for displaying player 2's score
    /// </summary>
    [SerializeField] private TMP_Text paddle2ScoreText;
    /// <summary>
    /// Transform component of player 1's paddle
    /// </summary>
    [SerializeField] private Transform paddle1Transform;
    /// <summary>
    /// Transform component of player 2's paddle
    /// </summary>
    [SerializeField] private Transform paddle2Transform;
    /// <summary>
    /// Transform component of the ball
    /// </summary>
    [SerializeField] private Transform ballTransform;

    /// <summary>
    /// Score of player 1
    /// </summary>
    private int paddle1Score;
    /// <summary>
    /// Score of player 2
    /// </summary>
    private int paddle2Score;

    /// <summary>
    /// Singleton instance of the GameManager
    /// </summary>
    private static GManager instance;
    /// <summary>
    /// Image object for displaying the win screen
    /// </summary>
    public GameObject winImage;

    /// <summary>
    /// Gets the singleton instance of the GManager.
    /// </summary>
    public static GManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GManager>();
            }
            return instance;
        }
    }

    /// <summary>
    /// Increases the score of player 1 and updates the UI.
    /// </summary>
    public void Paddle1Scored()
    {
        paddle1Score++;
        paddle1ScoreText.text = paddle1Score.ToString();
        if (paddle1Score >= 10 || paddle2Score >= 10)
        {
            Time.timeScale = 0; // Pausar el juego
            winImage.SetActive(true); 
        }

    }

    /// <summary>
    /// Increases the score of player 2 and updates the UI.
    /// </summary>
    public void Paddle2Scored()
    {
        paddle2Score++;
        paddle2ScoreText.text = paddle2Score.ToString();
        if (paddle1Score >= 10 || paddle2Score >= 10)
        {
            Time.timeScale = 0;
            winImage.SetActive(true);
        }

    }

    /// <summary>
    /// Restarts the game by resetting paddle and ball positions.
    /// </summary>
    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);

    }
}
