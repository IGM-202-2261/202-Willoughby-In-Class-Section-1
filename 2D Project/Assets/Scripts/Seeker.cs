using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject fearTarget;
    [SerializeField] private Agent evadeTarget;

    [SerializeField] private float seekWeight = 1f;
    [SerializeField] private float fleeWeight = 1f;
    [SerializeField] private float evadeWeight = 1f;
    [SerializeField] private float stayInBoundsWeight = 1f;
    [SerializeField] private float lookAheadSeconds = 0.5f;

    Vector3 totalForce;

    protected override Vector3 CalcSteering()
    {
        totalForce = Vector3.zero;

        totalForce += Seek(target) * seekWeight;
        totalForce += Flee(fearTarget) * fleeWeight;
        totalForce += Evade(evadeTarget, lookAheadSeconds) * evadeWeight;
        totalForce += StayInBounds(lookAheadSeconds) * stayInBoundsWeight;

        return totalForce;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(Vector3.zero, worldBounds);


        Vector3 posPlusVelocity = transform.position + velocity;

        Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(transform.position, posPlusVelocity);
        //
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(posPlusVelocity, posPlusVelocity + totalForce);

        Gizmos.DrawSphere(CalcFuturePosition(lookAheadSeconds), 0.3f);
    }
}
