using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.2f;

    void Update()
    {
        float moveH = Input.GetAxis("Horizontal") * moveSpeed;
        float moveV = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(moveH, 0.0f, moveV);
    }
}