using UnityEngine;

/// <summary>
/// Class that allows full movement of a character
/// </summary>
public class CharacterController2D : MonoBehaviour
{
    /// <summary>
    /// Amount of force added when the player jumps.
    /// </summary>
    [SerializeField] private float m_JumpForce = 150f;
    /// <summary>
    /// Amount of maxSpeed applied to crouching movement. 1 = 100%
    /// </summary>
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;
    /// <summary>
    /// How much to smooth out the movement
    /// </summary>
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    /// <summary>
    /// Whether or not a player can steer while jumping;
    /// </summary>
    [SerializeField] private bool m_AirControl = false;
    /// <summary>
    /// A mask determining what is ground to the character
    /// </summary>
    [SerializeField] private LayerMask m_WhatIsGround;
    /// <summary>
    /// A position marking where to check if the player is grounded.
    /// </summary>
    [SerializeField] private Transform m_GroundCheck;
    /// <summary>
    /// A position marking where to check for ceilings
    /// </summary>	
    [SerializeField] private Transform m_CeilingCheck;
    /// <summary>
    /// A collider that will be disabled when crouching
    /// </summary>
    [SerializeField] private Collider2D m_CrouchDisableCollider;				
	/// <summary>
	/// Radius of the overlap circle to determine if grounded
	/// </summary>
	const float k_GroundedRadius = .2f; 
	/// <summary>
	/// Whether or not the player is grounded.
	/// </summary>
	private bool m_Grounded;            
	/// <summary>
	/// Radius of the overlap circle to determine if the player can stand up
	/// </summary>	
	const float k_CeilingRadius = .2f;
    /// <summary>
    /// Represents the physics of the character
    /// </summary>
    private Rigidbody2D m_Rigidbody2D;
	/// <summary>
	/// For determining which way the player is currently facing.
	/// </summary>
	private bool m_FacingRight = true;
    /// <summary>
    /// Represents the speed of the character
    /// </summary>
    private Vector3 velocity = Vector3.zero;
    /// <summary>
    /// Current jump count
    /// </summary>
    private int m_JumpCount = 0;
    /// <summary>
    ///  Maximum number of jumps allowed
    /// </summary>
    public int m_MaxJumpCount = 2;
    /// <summary>
    ///  Modifier applied to the jump force for the second jump
    /// </summary>
    public float m_SecondJumpForceModifier = 0.5f;


    /// <summary>
    /// In this function the rigidbody is initialized
    /// </summary>
    private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}


    /// <summary>
    /// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
    /// </summary>
    private void FixedUpdate()
	{

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		
	}


    /// <summary>
    /// In this function we check if  the player is crouching, check to see if the character can stand up.
	/// If the character has a ceiling preventing them from standing up, keep them crouching.
	/// Also control the player if grounded or airControl is turned on. 
	/// If crouching, reduce the speed by the crouchSpeed multiplier, disable one of the colliders when crouching.
	/// If not crouching, enable the collider.
	/// Then move the character by finding the target velocity and then smoothing it out and applying it to the character.
	/// If the input is moving the player right and the player is facing left flip the player.
	/// Otherwise if the input is moving the player left and the player is facing right flip the player.
	/// If the player should jump add a vertical force to the player and the variable m_Grounded now is false.
	/// 
    /// </summary>
    /// <param name="move">Represent the character movement</param>
    /// <param name="crouch">Represents if the person is crouched</param>
    /// <param name="jump">Represents if the person is jumping</param>
    public void Move(float move, bool crouch, bool jump)
	{

		if (!crouch)
		{
			
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		if (m_Grounded || m_AirControl)
		{

			if (crouch)
			{
				move *= m_CrouchSpeed;

				
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;
			}

			
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			
			if (move > 0 && !m_FacingRight)
			{
				
				Flip();
			}
			
			else if (move < 0 && m_FacingRight)
			{
				
				Flip();
			}
		}

        if (m_JumpCount < m_MaxJumpCount && jump)
        {
            float jumpForce = m_JumpForce;
            if (m_JumpCount == 1)
            {
                jumpForce *= m_SecondJumpForceModifier;
            }

            m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            m_JumpCount++;
        }
    }

    /// <summary>
    /// Switch the way the player is labelled as facing and multiply the player's x local scale by -1.
    /// </summary>
    private void Flip()
	{
		
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


    /// <summary>
    /// Function that checks if the character is touching the ground.
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    private void OnCollisionEnter2D(Collision2D other)
	{
        if (other.gameObject.tag == "Ground")
        {
            m_Grounded = true;
            m_JumpCount = 0;
        }
    }

    /// <summary>
    /// Function that checks if the character is not touching the ground.
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    private void OnCollisionExit2D(Collision2D other)
	{
        if (other.gameObject.tag == "Ground")
        {
            m_Grounded = false;
        }
    }
}
