using Mono.Data.Sqlite;
using System;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that represents and will make it possible that the unity game connects with a data base.
/// </summary>
public class RankingBBDD : MonoBehaviour
{
    /// <summary>
    /// Variable representing the Ok button
    /// </summary>
    public GameObject OkButton;
    /// <summary>
    /// Variable that represents the ranking menu
    /// </summary>
    public GameObject rankingMenu;
    /// <summary>
    /// Variable that represents if the game is paused or not
    /// </summary>
    private bool isPaused = false;
    /// <summary>
    /// Variable that tells us if the ranking menu is active or not.
    /// </summary>
    Boolean isRankingMenuInScene = false;
    /// <summary>
    /// Variable representing the text field where the score will be displayed
    /// </summary>
    public TMPro.TMP_Text score;
    /// <summary>
    /// Variable representing the text field where the name will be displayed
    /// </summary>
    public TMPro.TMP_Text textScore;
    /// <summary>
    /// Variable representing what the user types in the name text field.
    /// </summary>
    public TMPro.TMP_InputField input;
    /// <summary>
    /// Variable representing the score 
    /// </summary>
    private String scoreText;
    /// <summary>
    /// Variable representing the name fetched from the database
    /// </summary>
    private String nameToDB;

    /// <summary>
    /// Function that takes the punctuation and the name in variables.
    /// </summary>

    void Update()
    {
        textScore.text = score.text;
        scoreText = textScore.text;
        
        nameToDB = input.text;

    }

    /// <summary>
    /// Function that detects that when the player collides with the statue at the end of the scene, the ranking menu appears.
    /// At that moment the game will be paused, and the player will have to write his name, to store the score obtained in the database.
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            rankingMenu.SetActive(true);
            isRankingMenuInScene = true;
            

            if (isRankingMenuInScene)
            {
                isPaused = true;
            }

            if (isPaused)
            {
                Time.timeScale = 0;                
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    /// <summary>
    /// In this function a connection to the database is created, through the IDbConnection class, 
    /// and an object capable of making queries in the database, of type IDbCommand.
    /// When the player clicks the Ok button, the score and name data will be inserted into the database.
    /// </summary>
    public void GoVictoryScene()
    {
        int numScore = int.Parse(scoreText);


        string conn = "URI=file:" + Application.dataPath + "/Plugins/SevenContinentVideoGame.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        var nameToInsert = input.text;
        string query = "INSERT INTO ScoreRanking (name, score) VALUES ('" + nameToInsert + "', " + numScore + ")";

        dbcmd.CommandText = query;
        IDataRecord reader = dbcmd.ExecuteReader();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        SceneManager.LoadScene("SubmarineSceneP2"); 
    }
}
