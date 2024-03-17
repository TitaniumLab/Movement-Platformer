using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BlockContact bottomLeftBlock;//left bottom part of cube
    [SerializeField] private BlockContact bottomRightBlock;//right bottom part of cube
    [SerializeField] private BlockContact upperLeftBlock;//left upper part of cube
    [SerializeField] private BlockContact upperRightBlock;//right upper part of cube

    private Rigidbody2D playerRigidbody;

    private float defaultGravity = 25;//default gravity value
    private Vector2 gravityDirection = Vector2.down; //default gravity direction

    private Animation rotateAnimation; //controls rotation animation




    //[SerializeField] private bool canRotateAgain = true; // prevents glitch after rotarion
    //[SerializeField] private bool canJumpAgain = true; // prevents glitch after jump
    //[SerializeField] private bool isRotating = false; //
    //[SerializeField] private bool jumpAfterRorating = false;
    //[SerializeField] private bool isRotating = false; //
    //[SerializeField] private bool isJumping = false; //


    private StateDB.MovementState movementState = StateDB.MovementState.idol;//default player state


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Physics2D.gravity = gravityDirection * defaultGravity;
        rotateAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        //movement

        if (Input.GetKey(KeyCode.A) && playerRigidbody.velocity == Vector2.zero && (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface) && movementState == StateDB.MovementState.idol)
            playerRigidbody.AddRelativeForce(Vector2.left * 2, ForceMode2D.Impulse);
        if (Input.GetKey(KeyCode.D) && playerRigidbody.velocity == Vector2.zero && (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface) && movementState == StateDB.MovementState.idol)
            playerRigidbody.AddRelativeForce(Vector2.right * 2, ForceMode2D.Impulse);
        if ((bottomLeftBlock.isOnSurface || bottomRightBlock.isOnSurface) && (movementState != StateDB.MovementState.rotaring && movementState != StateDB.MovementState.jumping))
            playerRigidbody.AddRelativeForce(Vector2.right * horizontalInput * Time.deltaTime * 1000);

        //stop sliding after button up
        //if (horizontalInput == 0 && bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface && (playerRigidbody.velocity.x != 0 || playerRigidbody.velocity.y != 0) && (!upperLeftBlock.isOnSurface && !upperRightBlock.isOnSurface))
        //{
        //    playerRigidbody.velocity = Vector2.zero;
        //}

        //default jump
        //if (Input.GetKeyDown(KeyCode.Space) && (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface) && !upperLeftBlock.isOnSurface && !upperRightBlock.isOnSurface)
        //{
        //    Jump();
        //}

        ////if try jump during rotating
        //if (Input.GetKeyDown(KeyCode.Space) && isRotating)
        //    jumpAfterRorating = true;

        ////if cube touches the ground with both edges
        //if (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface && !upperLeftBlock.isOnSurface && !upperRightBlock.isOnSurface && isJumping)
        //{
        //    isJumping = false;
        //}

        //// if one of the edges is hanging down, the cube is not in the air, has not recently rotated or jumped
        //if ((!bottomLeftBlock.isOnSurface || !bottomRightBlock.isOnSurface) && !(!bottomLeftBlock.isOnSurface && !bottomRightBlock.isOnSurface) && !isRotating && !isJumping)
        //{
        //    isRotating = true;
        //    ChangeDirection();
        //}


        //// if one of the top edges does not touch the surface, has not recently rotated or jumped
        //if ((!upperLeftBlock.isOnSurface || !upperRightBlock.isOnSurface) && !(!upperLeftBlock.isOnSurface && !upperRightBlock.isOnSurface) && (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface) && !isRotating)
        //{
        //    isRotating = true;
        //    ChangeDirectionInternal();
        //}

    }

    private void LateUpdate()
    {





    }

    private void FixedUpdate()
    {





    }


    /// <summary>
    /// change cube rotarion and grabity
    /// </summary>
    //private void ChangeDirection()
    //{
    //    Debug.Log("внешний");
    //    isRotating = true;
    //    playerRigidbody.velocity = Vector2.zero;
    //    if (bottomLeftBlock.isOnSurface && !bottomRightBlock.isOnSurface)
    //    {
    //        switch (state)
    //        {
    //            case StateDB.State.vectorUp:
    //                Physics2D.gravity = Vector2.left * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("1_UpToRightRotation");
    //                state = StateDB.State.vectorRight;
    //                break;
    //            case StateDB.State.vectorRight:
    //                Physics2D.gravity = Vector2.up * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("2_RightToDownRotation");
    //                state = StateDB.State.vectorDown;
    //                break;
    //            case StateDB.State.vectorDown:
    //                Physics2D.gravity = Vector2.right * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("3_DownToLeftRotation");
    //                state = StateDB.State.vectorLeft;
    //                break;
    //            case StateDB.State.vectorLeft:
    //                Physics2D.gravity = Vector2.down * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("4_LeftToUpRotation");
    //                state = StateDB.State.vectorUp;
    //                break;

    //        }
    //    }
    //    else
    //    {
    //        switch (state)
    //        {
    //            case StateDB.State.vectorUp:
    //                state = StateDB.State.vectorLeft;
    //                Physics2D.gravity = Vector2.right * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("5_UpToLeftRotation");
    //                break;
    //            case StateDB.State.vectorLeft:
    //                state = StateDB.State.vectorDown;
    //                Physics2D.gravity = Vector2.up * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("6_LeftToDownRotation");
    //                break;
    //            case StateDB.State.vectorDown:
    //                state = StateDB.State.vectorRight;
    //                Physics2D.gravity = Vector2.left * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("7_DownToRightRotation");
    //                break;
    //            case StateDB.State.vectorRight:
    //                state = StateDB.State.vectorUp;
    //                Physics2D.gravity = Vector2.down * Physics2D.gravity.magnitude;
    //                rotateAnimation.Play("8_RightToUpRotation");
    //                break;
    //        }
    //    }
    //}

    /// <summary>
    /// change cube rotarion and grabity on internal angle
    /// </summary>
    //private void ChangeDirectionInternal()
    //{
    //    isRotating = true;
    //    if (upperRightBlock.isOnSurface)
    //    {
    //        switch (state)
    //        {
    //            case StateDB.State.vectorUp:
    //                playerRigidbody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.right * defaultGravity;
    //                rotateAnimation.Play("5_UpToLeftRotation");
    //                state = StateDB.State.vectorLeft;
    //                break;
    //            case StateDB.State.vectorLeft:
    //                playerRigidbody.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.up * defaultGravity;
    //                rotateAnimation.Play("6_LeftToDownRotation");
    //                state = StateDB.State.vectorDown;
    //                break;
    //            case StateDB.State.vectorDown:
    //                playerRigidbody.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.left * defaultGravity;
    //                rotateAnimation.Play("7_DownToRightRotation");
    //                state = StateDB.State.vectorRight;
    //                break;
    //            case StateDB.State.vectorRight:
    //                playerRigidbody.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.down * defaultGravity;
    //                rotateAnimation.Play("8_RightToUpRotation");
    //                state = StateDB.State.vectorUp;
    //                break;


    //        }
    //    }
    //    else if (upperLeftBlock.isOnSurface)
    //    {
    //        switch (state)
    //        {
    //            case StateDB.State.vectorUp:
    //                playerRigidbody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.left * defaultGravity;
    //                rotateAnimation.Play("1_UpToRightRotation");
    //                state = StateDB.State.vectorRight;
    //                break;
    //            case StateDB.State.vectorRight:
    //                playerRigidbody.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.up * defaultGravity;
    //                rotateAnimation.Play("2_RightToDownRotation");
    //                state = StateDB.State.vectorDown;
    //                break;
    //            case StateDB.State.vectorDown:
    //                playerRigidbody.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.right * defaultGravity;
    //                rotateAnimation.Play("3_DownToLeftRotation");
    //                state = StateDB.State.vectorLeft;
    //                break;
    //            case StateDB.State.vectorLeft:
    //                playerRigidbody.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
    //                Physics2D.gravity = Vector2.down * defaultGravity;
    //                rotateAnimation.Play("4_LeftToUpRotation");
    //                state = StateDB.State.vectorUp;
    //                break;
    //        }
    //    }
    //}

    ///// <summary>
    ///// jump to the opposite wall
    ///// </summary>
    //private void Jump()
    //{
    //    playerRigidbody.velocity = Vector2.zero;
    //    switch (state)
    //    {
    //        case StateDB.State.vectorUp:
    //            playerRigidbody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    //            Physics2D.gravity = Vector2.up * defaultGravity;
    //            rotateAnimation.Play("10_JumpUp");
    //            state = StateDB.State.vectorDown;
    //            break;
    //        case StateDB.State.vectorDown:
    //            playerRigidbody.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
    //            Physics2D.gravity = Vector2.down * defaultGravity;
    //            rotateAnimation.Play("11_JumpDown");
    //            state = StateDB.State.vectorUp;
    //            break;
    //        case StateDB.State.vectorRight:
    //            playerRigidbody.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
    //            Physics2D.gravity = Vector2.right * defaultGravity;
    //            rotateAnimation.Play("12_JumpRight");
    //            state = StateDB.State.vectorLeft;
    //            break;
    //        case StateDB.State.vectorLeft:
    //            playerRigidbody.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
    //            Physics2D.gravity = Vector2.left * defaultGravity;
    //            rotateAnimation.Play("13_JumpLeft");
    //            state = StateDB.State.vectorRight;
    //            break;
    //    }
    //    jumpAfterRorating = false;
    //    isRotating = false;
    //    isJumping = true;
    //}


    ///// <summary>
    ///// default values after animation
    ///// </summary>
    //private void SetCanJumpAgain()
    //{
    //    jumpAfterRorating = false;
    //}

    ///// <summary>
    ///// if you try to jump while rotaring, the jump will occur in the last frame of the animation
    ///// </summary>
    //private void JumpAfterRorating()
    //{
    //    if (jumpAfterRorating == true)
    //        Jump();
    //    isRotating = false;
    //}
}
