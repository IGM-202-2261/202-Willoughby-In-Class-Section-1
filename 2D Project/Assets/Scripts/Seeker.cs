using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] private GameObject target;

    protected override Vector3 CalcSteering()
    {
        Vector3 totalForce = Vector3.zero;

        totalForce += Seek(target);

        return totalForce;
    }
}
