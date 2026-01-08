using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class Player_Movement : MonoBehaviour
{
    private bool isMovingLeft;
    private bool isMovingRight;
    

    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody2D rb;

    public LayerMask groundLayer;
    [NonSerialized] public bool isGrounded;
    [NonSerialized] public float raycastDistance = 0.6f;
    public float Jumpdistance;


    // Update is called once per frame
    void Update()
    {
        
        HandleMovement();

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer).collider != null;
        Debug.DrawRay(transform.position, Vector2.down * raycastDistance, Color.red);
    }

    private void HandleMovement()
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

        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Jumpdistance);
        }
    }
    
}
