using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float downSnapDistance = 2.0f;
    [SerializeField] private LayerMask walkableLayers;
    [SerializeField] private float heightCompensation = 0.1f;
    [SerializeField] private float jumpStrength = 100.0f;

    private Rigidbody rBody;
    private float height;
    private Vector3 playerMovement;
    private bool isGrounded;

    Vector3 projectedForward;
    Vector3 projectedRight;

    void Awake()
    {
        height = GetComponent<CapsuleCollider>().height / 2.0f;
        rBody = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        Vector3 groundNormal = Vector3.up;

        RaycastHit hit;
        if (isGrounded && Physics.Raycast(transform.position, Vector3.down,
            out hit, downSnapDistance, walkableLayers))
        {
            groundNormal = hit.normal;
        }

        projectedForward = Vector3.ProjectOnPlane(transform.forward, 
            groundNormal).normalized;
        projectedRight = Vector3.ProjectOnPlane(transform.right, 
            groundNormal).normalized;

        Vector3 pos = transform.position;
        pos += projectedRight * playerMovement.x * moveSpeed * Time.fixedDeltaTime;
        pos += projectedForward * playerMovement.y * moveSpeed * Time.fixedDeltaTime;
        transform.position = pos;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        playerMovement = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && isGrounded)
        {
            isGrounded = false;
            rBody.AddForce(Vector3.up * jumpStrength);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(((1 << other.gameObject.layer) & walkableLayers) != 0)
        {
            isGrounded = true;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + projectedForward);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + projectedRight);
    }
}
