using UnityEngine;

public class Wolf : Agent
{
    [SerializeField] private Agent prey;
    [SerializeField] private float pursueWeight = 1.0f;
    [SerializeField] private float stayInBoundsWeight = 1.0f;

    [SerializeField] private float pursueLookAhead = 1.0f;
    [SerializeField] private float pounceDistance = 0.5f;

    protected override Vector3 CalcSteering()
    {
        Vector3 totalForce = Vector3.zero;

        float distToPrey = Vector2.Distance(prey.transform.position, transform.position);
        distToPrey = Mathf.Min(2, distToPrey);
        float scaledPursueLookAhead = pursueLookAhead * distToPrey;
        totalForce += Pursue(prey, pursueLookAhead) * pursueWeight;

        //if(Vector2.Distance(prey.transform.position, transform.position) < pounceDistance)
        //{
        //    totalForce += Seek(prey.transform.position) * pursueWeight;
        //}
        //else
        //{
        //    totalForce += Pursue(prey, pursueLookAhead) * pursueWeight;
        //}
        totalForce += StayInBounds(pursueLookAhead) * stayInBoundsWeight;

        return totalForce;
    }
}
