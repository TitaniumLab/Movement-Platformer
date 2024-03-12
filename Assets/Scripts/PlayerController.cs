using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private BlockContact bottomLeftBlock;//left bottom part of cube
    [SerializeField]
    private BlockContact bottomRightBlock;//right bottom part of cube
    private Rigidbody2D playerRigidbody;
    private float horizontalInput;//value for movement
    private float defaultGravity = 20;//default gravity value
    private Animation rotateAnimation; //controls rotation animation
    private bool canRotateAgain = true; // prevents glitch after rotarion

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
        horizontalInput = Input.GetAxis("Horizontal");
        playerRigidbody.AddRelativeForce(Vector2.right * horizontalInput * Time.deltaTime * 1000);
    }

    private void FixedUpdate()
    {
        // if one of the edges is hanging down, cube is not in the air and has not recently rotated
        if ((!bottomLeftBlock.isOnSurface || !bottomRightBlock.isOnSurface) && !(!bottomLeftBlock.isOnSurface && !bottomRightBlock.isOnSurface) && canRotateAgain)
            ChangeDirection();

        //if cube touches the ground with both edges
        if (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface && !canRotateAgain)
            canRotateAgain = true;
    }


    /// <summary>
    /// change cube rotarion and grabity
    /// </summary>
    private void ChangeDirection()
    {
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
}
