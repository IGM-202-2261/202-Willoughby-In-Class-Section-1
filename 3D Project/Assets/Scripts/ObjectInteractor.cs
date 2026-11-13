using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteractor : MonoBehaviour
{
    [SerializeField] private float interactDistance = 5.0f;
    [SerializeField] private LayerMask interactLayers;

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            RaycastHit hit;
            bool hitAnObject = Physics.Raycast(
                transform.position,
                transform.forward,
                out hit,
                interactDistance,
                interactLayers);

            if(hitAnObject)
            {
                Material hitMaterial = hit.collider.gameObject.GetComponent<Renderer>().material;
                hitMaterial.color = Random.ColorHSV();
            }
        }
    }
}
