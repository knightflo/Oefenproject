using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    private bool isMovingLeft;
    private bool isMovingRight;

    [SerializeField] private float movementSpeed;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

        Debug.Log("jump start");
        Vector2 origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.6f, groundLayer);

        Debug.DrawRay(origin, Vector2.down * 0.6f, Color.red);

        if (hit.collider != null)
        {
            Debug.Log("jumping");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 5f);
        }
    }

}
