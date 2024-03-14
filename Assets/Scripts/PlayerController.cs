using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BlockContact bottomLeftBlock;//left bottom part of cube
    [SerializeField] private BlockContact bottomRightBlock;//right bottom part of cube
    [SerializeField] private BlockContact upperLeftBlock;//left upper part of cube
    [SerializeField] private BlockContact upperRightBlock;//right upper part of cube
    private Rigidbody2D playerRigidbody;
    [SerializeField] private float horizontalInput;//value for movement
    private float defaultGravity = 25;//default gravity value
    private Animation rotateAnimation; //controls rotation animation
    [SerializeField] private bool canRotateAgain = true; // prevents glitch after rotarion
    [SerializeField] private bool canJumpAgain = true; // prevents glitch after jump
    [SerializeField] private bool isRotating = false; //
    [SerializeField] private bool jumpAfterRorating = false;


    private enum State //all posible directions
    {
        vectorUp,
        vectorRight,
        vectorDown,
        vectorLeft
    }
    private State state = State.vectorUp;//default start state



    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Physics2D.gravity = Vector2.down * defaultGravity;
        rotateAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        //movement
        horizontalInput = Input.GetAxis("Horizontal");
        if (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface && canJumpAgain)
            playerRigidbody.AddRelativeForce(Vector2.right * horizontalInput * Time.deltaTime * 1000);
        //default jump
        if (Input.GetKeyDown(KeyCode.Space) && (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface) && !upperLeftBlock.isOnSurface && !upperRightBlock.isOnSurface)
            Jump();
        //if try jump during rotating
        if (Input.GetKeyDown(KeyCode.Space) && isRotating)
            jumpAfterRorating = true;

    }

    private void LateUpdate()
    {
        //if cube touches the ground with both edges
        if (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface && !canRotateAgain && !upperLeftBlock.isOnSurface && !upperRightBlock.isOnSurface)
            canRotateAgain = true;


    }

    private void FixedUpdate()
    {
        // if one of the edges is hanging down, the cube is not in the air, has not recently rotated or jumped
        if ((!bottomLeftBlock.isOnSurface || !bottomRightBlock.isOnSurface) && !(!bottomLeftBlock.isOnSurface && !bottomRightBlock.isOnSurface) && canRotateAgain && canJumpAgain)
            ChangeDirection();

        // if one of the top edges does not touch the surface, has not recently rotated or jumped
        if ((!upperLeftBlock.isOnSurface || !upperRightBlock.isOnSurface) && !(!upperLeftBlock.isOnSurface && !upperRightBlock.isOnSurface) && canRotateAgain && canJumpAgain)
            ChangeDirectionInternal();


        //stop sliding after button up
        if (horizontalInput == 0 && bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface && (playerRigidbody.velocity.x != 0 || playerRigidbody.velocity.y != 0) && canJumpAgain)
            playerRigidbody.velocity = Vector2.zero;
    }


    /// <summary>
    /// change cube rotarion and grabity
    /// </summary>
    private void ChangeDirection()
    {
        isRotating = true;
        playerRigidbody.velocity = Vector2.zero;
        if (bottomLeftBlock.isOnSurface && !bottomRightBlock.isOnSurface)
        {
            switch (state)
            {
                case State.vectorUp:
                    Physics2D.gravity = Vector2.left * defaultGravity;
                    rotateAnimation.Play("1_UpToRightRotation");
                    state = State.vectorRight;
                    break;
                case State.vectorRight:
                    Physics2D.gravity = Vector2.up * defaultGravity;
                    rotateAnimation.Play("2_RightToDownRotation");
                    state = State.vectorDown;
                    break;
                case State.vectorDown:
                    Physics2D.gravity = Vector2.right * defaultGravity;
                    rotateAnimation.Play("3_DownToLeftRotation");
                    state = State.vectorLeft;
                    break;
                case State.vectorLeft:
                    Physics2D.gravity = Vector2.down * defaultGravity;
                    rotateAnimation.Play("4_LeftToUpRotation");
                    state = State.vectorUp;
                    break;

            }
        }
        else
        {
            switch (state)
            {
                case State.vectorUp:
                    state = State.vectorLeft;
                    Physics2D.gravity = Vector2.right * defaultGravity;
                    rotateAnimation.Play("5_UpToLeftRotation");
                    break;
                case State.vectorLeft:
                    state = State.vectorDown;
                    Physics2D.gravity = Vector2.up * defaultGravity;
                    rotateAnimation.Play("6_LeftToDownRotation");
                    break;
                case State.vectorDown:
                    state = State.vectorRight;
                    Physics2D.gravity = Vector2.left * defaultGravity;
                    rotateAnimation.Play("7_DownToRightRotation");
                    break;
                case State.vectorRight:
                    state = State.vectorUp;
                    Physics2D.gravity = Vector2.down * defaultGravity;
                    rotateAnimation.Play("8_RightToUpRotation");
                    break;
            }
        }
        canRotateAgain = false;
    }

    /// <summary>
    /// change cube rotarion and grabity on internal angle
    /// </summary>
    private void ChangeDirectionInternal()
    {
        isRotating = true;
        if (upperRightBlock.isOnSurface)
        {
            switch (state)
            {
                case State.vectorUp:
                    playerRigidbody.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
                    Physics2D.gravity = Vector2.right * defaultGravity;
                    rotateAnimation.Play("5_UpToLeftRotation");
                    state = State.vectorLeft;
                    break;
                case State.vectorLeft:
                    playerRigidbody.AddForce(Vector2.left * 4, ForceMode2D.Impulse);
                    Physics2D.gravity = Vector2.up * defaultGravity;
                    rotateAnimation.Play("6_LeftToDownRotation");
                    state = State.vectorDown;
                    break;
                case State.vectorDown:
                    playerRigidbody.AddForce(Vector2.down * 4, ForceMode2D.Impulse);
                    Physics2D.gravity = Vector2.left * defaultGravity;
                    rotateAnimation.Play("7_DownToRightRotation");
                    state = State.vectorRight;
                    break;
                case State.vectorRight:
                    playerRigidbody.AddForce(Vector2.right * 4, ForceMode2D.Impulse);
                    Physics2D.gravity = Vector2.down * defaultGravity;
                    rotateAnimation.Play("8_RightToUpRotation");
                    state = State.vectorUp;
                    break;


            }
        }
        else if (upperLeftBlock.isOnSurface)
        {
            switch (state)
            {
                case State.vectorUp:
                    playerRigidbody.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
                    Physics2D.gravity = Vector2.left * defaultGravity;
                    rotateAnimation.Play("1_UpToRightRotation");
                    state = State.vectorRight;
                    break;
                case State.vectorRight:
                    playerRigidbody.AddForce(Vector2.right * 4, ForceMode2D.Impulse);
                    Physics2D.gravity = Vector2.up * defaultGravity;
                    rotateAnimation.Play("2_RightToDownRotation");
                    state = State.vectorDown;
                    break;
                case State.vectorDown:
                    playerRigidbody.AddForce(Vector2.down * 4, ForceMode2D.Impulse);
                    Physics2D.gravity = Vector2.right * defaultGravity;
                    rotateAnimation.Play("3_DownToLeftRotation");
                    state = State.vectorLeft;
                    break;
                case State.vectorLeft:
                    playerRigidbody.AddForce(Vector2.left * 4, ForceMode2D.Impulse);
                    Physics2D.gravity = Vector2.down * defaultGravity;
                    rotateAnimation.Play("4_LeftToUpRotation");
                    state = State.vectorUp;
                    break;
            }
        }
        canRotateAgain = false;
    }

    /// <summary>
    /// jump to the opposite wall
    /// </summary>
    private void Jump()
    {
        playerRigidbody.velocity = Vector2.zero;
        switch (state)
        {
            case State.vectorUp:
                playerRigidbody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                Physics2D.gravity = Vector2.up * defaultGravity;
                rotateAnimation.Play("10_JumpUp");
                state = State.vectorDown;
                break;
            case State.vectorDown:
                playerRigidbody.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
                Physics2D.gravity = Vector2.down * defaultGravity;
                rotateAnimation.Play("11_JumpDown");
                state = State.vectorUp;
                break;
            case State.vectorRight:
                playerRigidbody.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
                Physics2D.gravity = Vector2.right * defaultGravity;
                rotateAnimation.Play("12_JumpRight");
                state = State.vectorLeft;
                break;
            case State.vectorLeft:
                playerRigidbody.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
                Physics2D.gravity = Vector2.left * defaultGravity;
                rotateAnimation.Play("13_JumpLeft");
                state = State.vectorRight;
                break;
        }
        canJumpAgain = false;
        jumpAfterRorating = false;
    }


    /// <summary>
    /// default values after animation
    /// </summary>
    private void SetCanJumpAgain()
    {
        canJumpAgain = true;
        jumpAfterRorating = false;
    }

    /// <summary>
    /// if you try to jump while rotaring, the jump will occur in the last frame of the animation
    /// </summary>
    private void JumpAfterRorating()
    {
        if (jumpAfterRorating == true)
            Jump();
        isRotating = false;
    }
}
