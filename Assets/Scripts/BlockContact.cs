using UnityEngine;

public class BlockContact : MonoBehaviour
{
    public bool isOnSurface;//if edge touches surface

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Surface")
            isOnSurface = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Surface")
            isOnSurface = false;
    }
}
