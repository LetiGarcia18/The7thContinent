using UnityEngine;

/// <summary>
/// Class that makes that the camera follows the player.
/// </summary>
public class Camera : MonoBehaviour
{
    /// <summary>
    /// Varibale that represents the camera velocity.
    /// </summary>
    public float interpVelocity;
    /// <summary>
    /// Varibale that represents the minimun distance to the player.
    /// </summary>
    public float minDistance;
    /// <summary>
    /// Variable that represents the constant distance that has the camera while follow the player.
    /// </summary>
    public float followDistance;
    /// <summary>
    /// Variable that represents the player.
    /// </summary>
    public GameObject target;
    /// <summary>
    /// Variable that represents the position of the camenra in the X axis and the Y axis.
    /// </summary>
    public Vector3 offset;
    /// <summary>
    /// Variable thar represents the position of the player in the X axis and the Y axis.
    /// </summary>
    Vector3 targetPos;


    /// <summary>
    /// In the Start method, value is given to the position of the player.
    /// </summary>
    void Start()
    {
        targetPos = transform.position;
    }

    /// <summary>
    /// In this method, it first checks if there is a player, and if there is, 
    /// the camera will be given a speed and position in such a way that it will 
    /// follow the player's position at all times.
    /// </summary>
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }
}
