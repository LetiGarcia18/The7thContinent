using UnityEngine;

/// <summary>
/// This is for the selection character apears in the Menu Scene
/// </summary>
[CreateAssetMenu(fileName = "NewCharacter", menuName = "MenuCharacterElection")]

/// <summary>
/// This Class contains a GameObject as a character, a Sprite as a image of this character, and a string as a name of this characte
/// </summary>
public class Character : ScriptableObject
{
    public GameObject character;
    public Sprite imagen;
    public string characterName;
}
