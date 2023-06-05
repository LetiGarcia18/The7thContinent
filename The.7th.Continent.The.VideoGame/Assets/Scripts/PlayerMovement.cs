using UnityEngine;

/// <summary>
/// Function that represents the movement of the character horizontally, the jump of the character, and the character crouching
/// </summary>
public class PlayerMovement : MonoBehaviour {
    /// <summary>
    /// Represents the object that moves the character
    /// </summary>
    public CharacterController2D controller;
    /// <summary>
    /// Represents the speed at which the character runs
    /// </summary>
    public float runSpeed;
    /// <summary>
    /// Renders character animations
    /// </summary>
    public Animator animator;
    /// <summary>
    /// It represents the horizontal movement
    /// </summary>
    private float horizontalMove = 0f;
    /// <summary>
    /// It represents the jump of the character. Starts false, it means the character is not jumping
    /// </summary>
    private bool jump = false;
    /// <summary>
    /// It represents that character. get down Starts false, it means the character is not crouched.
    /// </summary>
    private bool crouch = false;

    /// <summary>
    /// Represents the acceleration time of the character.
    /// </summary>
    private float timeAccelerated = 0f;

    /// <summary>
    /// Function that assigns the actions of movement, jump and crouch to keys.
    /// It also checks that the acceleration time is greater than zero. If it is, for each frame, 
    /// the acceleration time is subtracted by a time.deltaTime.
    /// </summary>
    void Update () {

        var acceleration = 1f;
        if (timeAccelerated > 0f) {
            acceleration = 2f;
            timeAccelerated -= Time.deltaTime;
        }

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * acceleration;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

    /// <summary>
    /// Function that move our character
    /// </summary>
	void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

    /// <summary>
    /// Function that, to the acceleration time, gives the value of the accelerated seconds.
    /// </summary>
    /// <param name="secondsAccelerated"></param>
    public void SetAccelerationForSeconds(float secondsAccelerated)
    {
        timeAccelerated = secondsAccelerated;
    }
}
