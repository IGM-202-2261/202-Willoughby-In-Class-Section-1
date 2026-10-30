using UnityEngine;
using System.Collections.Generic;

public class FlockCoordinator : MonoBehaviour
{
    [SerializeField] private Agent agentPrefab;
    [SerializeField] private int numAgents = 10;
    List<Agent> flock;

    public Vector3 AverageVelocity { get; private set; }
    public Vector3 AveragePosition { get; private set; }

    void Awake()
    {
        flock = new List<Agent>();
        for(int i = 0; i < numAgents; i++)
        {
            flock.Add(Instantiate(agentPrefab, transform));
        }
    }

    private void FixedUpdate()
    {
        AverageVelocity = Vector3.zero;
        AveragePosition = Vector3.zero;

        if (flock.Count == 0) return;

        for(int i = 0; i < flock.Count; i++)
        {
            AverageVelocity += flock[i].Velocity;
            AveragePosition += flock[i].transform.position;
        }

        AverageVelocity /= flock.Count;
        AveragePosition /= flock.Count;
    }

    public Agent[] GetNearby(Agent me, float nearbyRadius)
    {
        List<Agent> nearby = new List<Agent>();
        for(int i = 0; i < flock.Count; i++)
        {
            if (flock[i] == me) continue;

            float dist = Vector2.Distance
                (me.transform.position, flock[i].transform.position);

            if(dist <= nearbyRadius)
            {
                nearby.Add(flock[i]);
            }
        }

        return nearby.ToArray();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(AveragePosition, 0.5f);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(AveragePosition, AveragePosition + AverageVelocity);
    }
}
