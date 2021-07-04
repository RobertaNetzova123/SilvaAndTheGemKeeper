using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;

    private bool jumpKeyWasPressed = false;
   

    //variables for ground check
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //variabled for wall check (wall jumping)
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;
    public float yWallForce;
    public float wallJumpTime;

    //animation
    private bool jumping = false;
    [SerializeField] Animator animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //left/right movement
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement * Time.deltaTime * MovementSpeed, 0, 0);

        //flipping the sprite when moving
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        //Animator walking animation
        animator.SetFloat("Speed", Mathf.Abs(movement * MovementSpeed));

        //jumping
        /*if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }*/

        //jumping read and make the if in the update 
        //physics changes are made here
        if (jumping)
        {

            // first time we read we read the player is grounded because the jump has just stared
            if (isGrounded && jumpKeyWasPressed)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                jumpKeyWasPressed = false;
                animator.SetBool("IsJumping", true);
                print("Jump in FixedUpdate");
            }
            // covers the other reads when the key was not pressed (even if it is pressed we wouldn't change the boolean since there is a check for that in Update) 
            else if (isGrounded && !jumpKeyWasPressed)
            {
                print("Land");
                animator.SetBool("IsJumping", false);
                jumping = false;
            }

        }

        //wall jumping script
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if (isTouchingFront == true && isGrounded == false)
            wallSliding = true;
        else
            wallSliding = false;

        if (wallSliding)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Clamp(_rigidbody.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

       

        if (wallJumping == true)
        {
            _rigidbody.velocity = new Vector2(0, yWallForce);
        }

        if (wallSliding || wallJumping || !isGrounded)
        {
            animator.SetBool("IsJumping", true);
        }
        else if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private void Update()
    {
        // left/right movement input
       

        //check jump input 
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            print("JUMP " + Mathf.Abs(_rigidbody.velocity.y));
            jumpKeyWasPressed = true;
            jumping = true;

        }

        //check wall jumping input
        if (Input.GetButtonDown("Jump") && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
}
