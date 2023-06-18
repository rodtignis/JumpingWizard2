using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoviment : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float minX = -2.5f;
    public float maxX = 2.5f;

    private bool moveRight = true;

    private void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x >= maxX)
        {
            moveRight = false;
        }
        else if (transform.position.x <= minX)
        {
            moveRight = true;
        }
    }
}
