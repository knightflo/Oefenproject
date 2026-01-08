using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player_Transform : MonoBehaviour
{
    private bool isUpsideDown = false;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Player_Movement playerMovement;
    [SerializeField] private Rigidbody2D RB;

    [SerializeField] private Transform transformBlack;
    [SerializeField] private Transform transformWhite;

    private List<Collider2D> Blackcolliders = new List<Collider2D>();
    private List<Collider2D> Whitecolliders = new List<Collider2D>();

    private void Awake()
    {
        GetallCollidersfromLayers();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transform(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || !playerMovement.isGrounded) return;

        ToggleColor();
        if (!isUpsideDown) 
        {
            transform.position = transformWhite.position;
            playerMovement.groundLayer = LayerMask.GetMask("GroundWhite");
        }
        else
        {
            transform.position = transformBlack.position;
            playerMovement.groundLayer = LayerMask.GetMask("GroundBlack");
        }

        foreach (Collider2D colliders in Whitecolliders)
        {
            colliders.isTrigger = !colliders.isTrigger;
        }
        foreach (Collider2D colliders in Blackcolliders)
        {
            colliders.isTrigger = !colliders.isTrigger;
        }
        RB.gravityScale = -RB.gravityScale;
        isUpsideDown = !isUpsideDown;
        playerMovement.raycastDistance = -playerMovement.raycastDistance;
        playerMovement.Jumpdistance = -playerMovement.Jumpdistance;
    }
    private void GetallCollidersfromLayers()
    {
        Collider2D[] colliders = Object.FindObjectsByType<Collider2D>(FindObjectsSortMode.None);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.layer == 6)
            {
                Blackcolliders.Add(collider);
            }
            if (collider.gameObject.layer == 7)
            {
                Whitecolliders.Add(collider);
            }
        }
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
