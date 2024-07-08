using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickHandling : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] float joyStickMagnitude;

    [Header("Required to attach")]
    Rigidbody2D rb;
    [SerializeField] Joystick movementJoystick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if(movementJoystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.Direction.x, movementJoystick.Direction.y) * joyStickMagnitude;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
