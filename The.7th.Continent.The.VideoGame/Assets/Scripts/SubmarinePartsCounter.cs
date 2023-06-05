using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Class representing the submarine game pieces
/// </summary>
public class SubmarinePartsCounter : MonoBehaviour
{
    /// <summary>
    /// Represents the text of the submarine pieces
    /// </summary>
    public TextMeshProUGUI tarjetCounter;
    /// <summary>
    /// Represents the submarine parts counter
    /// </summary>
    public TextMeshProUGUI counterNumber;
    /// <summary>
    /// Represents the text that appears if you can't find the submarine pieces
    /// </summary>
    public TextMeshProUGUI findSubmarinePieceText;

    /// <summary>
    /// Function that initializes the counter to zero
    /// </summary>
    void Start()
    {
        counterNumber.text = "0";
    }

    /// <summary>
    /// Function that counts in scene the submarine pieces that the character takes
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            tarjetCounter.gameObject.SetActive(true);
            counterNumber.text = (Int32.Parse(counterNumber.text) + 1).ToString();
            findSubmarinePieceText.gameObject.SetActive(false);
        }
    }
}
