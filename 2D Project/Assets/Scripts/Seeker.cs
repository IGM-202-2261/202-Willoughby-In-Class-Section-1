using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject fearTarget;

    [SerializeField] private float seekWeight = 1f;
    [SerializeField] private float fleeWeight = 1f;
    [SerializeField] private float stayInBoundsWeight = 1f;

    Vector3 totalForce;

    protected override Vector3 CalcSteering()
    {
        totalForce = Vector3.zero;

        totalForce += Seek(target) * seekWeight;
        totalForce += Flee(fearTarget) * fleeWeight;
        totalForce += StayInBounds() * stayInBoundsWeight;

        return totalForce;
    }

    private void OnDrawGizmos()
    {
        Vector3 posPlusVelocity = transform.position + velocity;

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, posPlusVelocity);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(posPlusVelocity, posPlusVelocity + totalForce);
    }
}
