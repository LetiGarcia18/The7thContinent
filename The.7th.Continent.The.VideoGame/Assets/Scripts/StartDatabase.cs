using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

/// <summary>
/// Class that will start and create the database when starting the game
/// </summary>
public class StartDatabase : MonoBehaviour
{
    /// <summary>
    /// At start, the connection to the database will be made, and the tables it has will be created.
    /// </summary>
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/SevenContinentVideoGame.db"; //Path to database.
        IDbConnection dbconn;

        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand();

        string query = "CREATE TABLE IF NOT EXISTS [ScoreRanking] (" +
            "[name]	TEXT," +
            "[score] INTEGER," +
            "[date]	TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
            "PRIMARY KEY([name],[date])" +
            ")";

        dbcmd.CommandText = query;
        IDataRecord reader = dbcmd.ExecuteReader();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
