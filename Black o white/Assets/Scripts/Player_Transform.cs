using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Player_Transform : MonoBehaviour
{
    private bool isUpsideDown = false;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Player_Movement playerMovement;
    [SerializeField] private Player_Collide playerCollide;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform transformBlack;
    [SerializeField] private Transform transformWhite;

    [SerializeField] private Collider2D blackCollider;
    [SerializeField] private Collider2D whiteCollider;

    [SerializeField] private Transform raycastLeft;
    [SerializeField] private Transform raycastRight;

    [SerializeField] private LayerMask groundLayer;
    private void Awake()
    {
        whiteCollider.isTrigger = false;
    }

    private bool isGrounded()
    {
        return Physics2D.Raycast(raycastLeft.position, Vector2.down, playerMovement.raycastDistance, groundLayer).collider != null
            && Physics2D.Raycast(raycastRight.position, Vector2.down, playerMovement.raycastDistance, groundLayer).collider != null;
    }
    public void Transform(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || !isGrounded()) return;

        ToggleColor();
        if (!isUpsideDown) 
        {
            transform.position = transformWhite.position;
            groundLayer = LayerMask.GetMask("GroundWhite");
            playerCollide.spikeTag = "SpikeWhite";
        }
        else
        {
            transform.position = transformBlack.position;
            groundLayer = LayerMask.GetMask("GroundBlack");
            playerCollide.spikeTag = "SpikeBlack";
        }

        blackCollider.isTrigger = !blackCollider.isTrigger;
        whiteCollider.isTrigger = !whiteCollider.isTrigger;
        rb.gravityScale = -rb.gravityScale;
        rb.linearVelocityY = 0;
        isUpsideDown = !isUpsideDown;
        playerMovement.raycastDistance = -playerMovement.raycastDistance;
        playerMovement.Jumpdistance = -playerMovement.Jumpdistance;
    }
    
    public void ToggleColor()
    {
        if (!isUpsideDown)
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.black;
        }
    }
}
