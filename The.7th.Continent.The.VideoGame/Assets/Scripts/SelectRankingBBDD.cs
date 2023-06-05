using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

/// <summary>
/// Class representing the ranking menu. This menu is accessed from the Start menu.
/// </summary>
public class SelectRankingBBDD : MonoBehaviour
{
    /// <summary>
    /// Variable representing player 1's score, name, and date data
    /// </summary>
    public GameObject score1;
    /// <summary>
    /// Variable representing player 2's score, name, and date data
    /// </summary>
    public GameObject score2;
    /// <summary>
    /// Variable representing player 3's score, name, and date data
    /// </summary>
    public GameObject score3;
    /// <summary>
    /// Variable representing player 4's score, name, and date data
    /// </summary>
    public GameObject score4;
    /// <summary>
    /// Variable representing player 5's score, name, and date data
    /// </summary>
    public GameObject score5;
    /// <summary>
    /// Variable that tells us if the ranking menu is active
    /// </summary>
    private Boolean isRanking = false;
    /// <summary>
    /// Represents de ranking menu
    /// </summary>
    public GameObject rankingMenu;

    /// <summary>
    /// At Start, the connection to the database is made, and a query is performed.
    /// In this query, only the top 5 scores will be returned, sorted in descending order. From the highest, to the lowest.
    /// </summary>
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/SevenContinentVideoGame.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM ScoreRanking ORDER BY score DESC LIMIT 5";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        List<ScoreData> scoreDatas = new List<ScoreData>();
        

        while (reader.Read())
        {
            //rellenas
            var name = reader.GetString(0);
            var score = reader.GetInt32(1);
            var date = reader.GetDateTime(2);

            scoreDatas.Add(new ScoreData(name, score, date));
        }
        
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        WritePlayerScore(score1, scoreDatas, 0);
        WritePlayerScore(score2, scoreDatas, 1);
        WritePlayerScore(score3, scoreDatas, 2);
        WritePlayerScore(score4, scoreDatas, 3);
        WritePlayerScore(score5, scoreDatas, 4);
    }

    /// <summary>
    /// In this function, the Text component of the children is fetched.
    /// </summary>
    /// <param name="parent">Represents the parent object</param>
    /// <param name="tag">Represents the tag with which the children will be searched within the parent</param>
    /// <returns></returns>
    private TMP_Text GetTextComponentWithTag(GameObject parent, string tag)
    {
        TMP_Text textComponentWithTag = null;
        var listOfTextComponents = parent.GetComponentsInChildren<TMP_Text>();
        foreach (TMP_Text textComponent in listOfTextComponents)
        {
            if (textComponent.tag == tag)
            {
                textComponentWithTag = textComponent;
            }
        }
        return textComponentWithTag;
    }

    /// <summary>
    /// function that writes in the text fields, the punctuation, the name and the date fetched from the database.
    /// </summary>
    /// <param name="score"></param>
    /// <param name="scoreData"></param>
    private void WritePlayerScore(GameObject score, List<ScoreData> scoreDatas, int position)
    {
        if (position < scoreDatas.Count)
        {
            var scoreData = scoreDatas[position];

            var playerScoreChild = GetTextComponentWithTag(score, "playerScore");
            playerScoreChild.text = scoreData.Score.ToString();

            var playerTextChild = GetTextComponentWithTag(score, "playerText");
            playerTextChild.text = scoreData.Name;

            var playerDateChild = GetTextComponentWithTag(score, "playerDate");
            playerDateChild.text = scoreData.Date.ToString();
        }
    }

    /// <summary>
    /// Function that activates the ranking menu by clicking on its button.
    /// </summary>
    public void GoToSeeScores()
    {
        isRanking = true;
        if (isRanking) 
        {
            rankingMenu.SetActive(true);
        }
    }
}
