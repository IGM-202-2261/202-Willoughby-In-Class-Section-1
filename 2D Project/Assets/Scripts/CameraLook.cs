using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity = 0.001f;

    Vector3 lastDirection;

    public void OnLook(InputAction.CallbackContext ctx)
    {
        Vector2 lookVec = ctx.ReadValue<Vector2>();
        lastDirection = (Vector3)lookVec * mouseSensitivity;
    }

    void Update()
    {
        transform.position += lastDirection;
    }
}