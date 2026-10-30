using System;
using UnityEngine;

public class Bird : Agent
{
    private FlockCoordinator flock;
    [SerializeField] private float cohesionWeight = 1.0f;
    [SerializeField] private float alignmentWeight = 1.0f;
    [SerializeField] private float separateWeight = 1.0f;
    [SerializeField] private float separateDistance = 4.0f;
    [SerializeField] private float stayInBoundsWeight = 1.0f;
    [SerializeField] private float stayInBoundsLookAhead = 1.0f;

    [SerializeField] private float wanderWeight = 1.0f;
    [SerializeField] private float wanderJitter = 1.0f;
    [SerializeField] private float wanderLookAhead = 1.0f;
    [SerializeField] private float wanderRadius = 1.0f;


    void Awake()
    {
        flock = transform.parent.gameObject.GetComponent<FlockCoordinator>();
    }

    protected override Vector3 CalcSteering()
    {
        Vector3 totalForce = Vector3.zero;

        totalForce += Wander(wanderJitter, wanderLookAhead, wanderRadius) * wanderWeight;

        totalForce += StayInBounds(stayInBoundsLookAhead) * stayInBoundsWeight;

        //Cohesion
        totalForce += Seek(flock.AveragePosition) * cohesionWeight;

        //Alignment
        totalForce += Alignment(flock.AverageVelocity, true) * alignmentWeight;

        //Separate
        Agent[] nearby = flock.GetNearby(this, separateDistance);
        totalForce += Separate(nearby, separateDistance) * separateWeight;

        return totalForce;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(Vector3.zero, worldBounds);
    }
}
