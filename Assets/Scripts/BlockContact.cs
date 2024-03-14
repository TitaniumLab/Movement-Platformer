using System.Collections.Generic;
using UnityEngine;

public class BlockContact : MonoBehaviour
{
    public bool isOnSurface;//is edge touches surface
    private List<GameObject> surfaces = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Surface")
        {
            surfaces.Add(collision.gameObject);
            isOnSurface = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Surface" && surfaces.Count < 2)
            isOnSurface = false;
        surfaces.Remove(collision.gameObject);
    }
}
