using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    private Vector3 playerMovement;

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos += transform.right * playerMovement.x * moveSpeed * Time.fixedDeltaTime;
        pos += transform.forward * playerMovement.y * moveSpeed * Time.fixedDeltaTime;
        transform.position = pos;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        playerMovement = ctx.ReadValue<Vector2>();
    }
}
