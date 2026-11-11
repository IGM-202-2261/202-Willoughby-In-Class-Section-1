using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float xLookSpeed = 1.0f;
    [SerializeField] private float yLookSpeed = 1.0f;
    [SerializeField] private GameObject body;

    private float yRot = 0;

    private void Awake()
    {
        yRot = transform.rotation.eulerAngles.x;
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        Vector2 lookInput = ctx.ReadValue<Vector2>();

        if(lookInput.x != 0)
        {
            body.transform.Rotate(0f, lookInput.x * xLookSpeed, 0);
        }

        if (lookInput.y != 0)
        {
            if (lookInput.y < 0 && yRot < 89
                || lookInput.y > 0 && yRot > -89)
            {
                yRot += -lookInput.y * yLookSpeed;
                transform.Rotate(-lookInput.y * yLookSpeed, 0, 0);
            }
        }
    }
}
