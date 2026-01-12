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
    [SerializeField] private Player_Death playerDeath;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform transformBlack;
    [SerializeField] private Transform transformWhite;

    [SerializeField] private Collider2D BlackCollider;
    [SerializeField] private Collider2D WhiteCollider;
    private void Awake()
    {
        WhiteCollider.isTrigger = false;
    }

    public void Transform(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || !playerMovement.isGrounded) return;

        ToggleColor();
        if (!isUpsideDown) 
        {
            transform.position = transformWhite.position;
            playerMovement.groundLayer = LayerMask.GetMask("GroundWhite");
            playerDeath.spikeTag = "SpikeWhite";
        }
        else
        {
            transform.position = transformBlack.position;
            playerMovement.groundLayer = LayerMask.GetMask("GroundBlack");
            playerDeath.spikeTag = "SpikeBlack";
        }

        BlackCollider.isTrigger = !BlackCollider.isTrigger;
        WhiteCollider.isTrigger = !WhiteCollider.isTrigger;
        rb.gravityScale = -rb.gravityScale;
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
