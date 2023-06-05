using System;


/// <summary>
/// The class representing the scoring data.
/// </summary>
public class ScoreData
{
    /// <summary>
    /// Represents the character name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Represents the score character
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Represents the date on which the insertion was made to the database
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// class constructor
    /// </summary>
    /// <param name="name">Represents the character name.</param>
    /// <param name="score">Represents the score character</param>
    /// <param name="date">Represents the date on which the insertion was made to the database</param>
    public ScoreData(string name, int score, DateTime date)
    {
        Name = name;
        Score = score;
        Date = date;
    }

  
}
