using TMPro;
using UnityEngine;

/// <summary>
/// Class that represents the count of gems in a scene.
/// </summary>
public class GemsCounter : MonoBehaviour
{
    /// <summary>
    /// Represents the descriptive text of the gems.
    /// </summary>
    public TextMeshProUGUI tarjetCounter;
    /// <summary>
    /// Represents the number of gems collected.
    /// </summary>
    public TextMeshProUGUI counterNumber;
    /// <summary>
    /// The name of the scene to load when triggered by collision.
    /// </summary>
    public string sceneName;
    /// <summary>
    /// The current number of collected gems.
    /// </summary>
    private int gems = 0;
    /// <summary>
    /// The temporary number of gems used for calculations or temporary storage.
    /// </summary>
    private int temporalGems = 0;

    /// <summary>
    /// A value of "0" is given to the text that represents the number of gems.
    /// </summary>
    void Start()
    {
        if (sceneName == "Level1")
        {
            PlayerPrefs.SetInt("gems", 0);
            PlayerPrefs.SetInt("temporalGems", 0);
        }

        gems = PlayerPrefs.GetInt("gems");
        counterNumber.text = gems.ToString();
    }

    /// <summary>
    /// Each time the character touches a gem, add +1 to the gem counter text.
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gems = PlayerPrefs.GetInt("gems");
            temporalGems = PlayerPrefs.GetInt("temporalGems");

            gems++;
            temporalGems++;

            tarjetCounter.gameObject.SetActive(true);
            counterNumber.text = gems.ToString();

            PlayerPrefs.SetInt("gems", gems);
            PlayerPrefs.SetInt("temporalGems", temporalGems);
        }
    }
}
