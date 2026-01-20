using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse_Position : MonoBehaviour
{
    [SerializeField] private Camera camera;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            MouseCollide();
        }
    }

    private void MouseCollide()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(
            worldPos,
            Vector2.zero
        );

        if (hit.collider != null && hit.collider.CompareTag("Rust"))
        {
            UI_Manager.instance.Paint(hit.collider.gameObject);
        }
    }
}
