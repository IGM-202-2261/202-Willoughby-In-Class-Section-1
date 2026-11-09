using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float xLookSpeed = 1.0f;
    [SerializeField] private float yLookSpeed = 1.0f;
    [SerializeField] private GameObject body;

    public void OnLook(InputAction.CallbackContext ctx)
    {
        Vector2 lookInput = ctx.ReadValue<Vector2>();

        if(lookInput.x != 0)
        {
            body.transform.Rotate(0f, lookInput.x * xLookSpeed, 0);
        }

        if(lookInput.y != 0)
        {
            transform.Rotate(lookInput.y * yLookSpeed, 0, 0);
        }
    }
}
