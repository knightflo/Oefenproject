using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    private bool isMovingLeft;
    private bool isMovingRight;

    [NonSerialized] public bool canMove = true;

    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    [NonSerialized] public float raycastDistance = 0.6f;
    public float Jumpdistance;

    [SerializeField] private Transform raycastLeft;
    [SerializeField] private Transform raycastRight;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(raycastLeft.position, Vector2.down, raycastDistance, groundLayer).collider != null
            || Physics2D.Raycast(raycastRight.position, Vector2.down, raycastDistance, groundLayer).collider != null;
    }

    private void HandleMovement()
    {
        if (canMove)
        {
            if (isMovingLeft)
            {
                rb.linearVelocityX = -1 * movementSpeed;
            }
            else if (isMovingRight)
            {
                rb.linearVelocityX = +1 * movementSpeed;
            }
            else
            {
                rb.linearVelocityX = 0;
            }
        }
        else
        {
            rb.linearVelocityX = 0;
        }
    }

    public void SetMovementLeft(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            isMovingLeft = true;
        }
        else if (ctx.canceled)
        {
            isMovingLeft = false;
        }
    }

    public void SetMovementRight(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            isMovingRight = true;
        }
        else if (ctx.canceled)
        {
            isMovingRight = false;
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;

        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Jumpdistance);
        }
    }
}
