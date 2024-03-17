
using UnityEngine;
using static StateDB;

public class Movement : MonoBehaviour
{
    [SerializeField] private BlockContact bottomLeftBlock;//left bottom part of cube
    [SerializeField] private BlockContact bottomRightBlock;//right bottom part of cube
    private Rigidbody2D playerRigidbody2D;

    private float horizontalInput;
    private float verticalInput;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        if (horizontalInput != 0 || verticalInput)
        {

        }
    }

    public void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A) && playerRigidbody.velocity == Vector2.zero && (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface) && movementState == StateDB.MovementState.idol)
            playerRigidbody.AddRelativeForce(Vector2.left * 2, ForceMode2D.Impulse);
        if (Input.GetKey(KeyCode.D) && playerRigidbody.velocity == Vector2.zero && (bottomLeftBlock.isOnSurface && bottomRightBlock.isOnSurface) && movementState == StateDB.MovementState.idol)
            playerRigidbody.AddRelativeForce(Vector2.right * 2, ForceMode2D.Impulse);
        if ((bottomLeftBlock.isOnSurface || bottomRightBlock.isOnSurface) && (movementState != StateDB.MovementState.rotaring && movementState != StateDB.MovementState.jumping))
            playerRigidbody.AddRelativeForce(Vector2.right * horizontalInput * Time.deltaTime * 1000);
    }

}
