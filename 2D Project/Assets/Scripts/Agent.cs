using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] private float maxSpeed;

    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected Vector3 steeringForce;

    protected Vector3 wanderTarget;

    [SerializeField] protected Vector3 worldBounds;

    public Vector3 Velocity { get { return velocity; } }

    protected abstract Vector3 CalcSteering();

    private void FixedUpdate()
    {
        acceleration = Vector3.zero;

        steeringForce = CalcSteering();
        acceleration += steeringForce;

        Vector3 nextPosition = transform.position;

        velocity += acceleration * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        nextPosition += velocity * Time.fixedDeltaTime;

        rBody.MovePosition(nextPosition);
    }

    protected Vector3 CalcFuturePosition(float seconds)
    {
        Vector3 velocityTimesTime = velocity * seconds;
        return transform.position + velocityTimesTime;
    }


    // Steering Behaviors
    protected Vector3 Seek(Vector3 targetPos)
    {
        Vector3 desiredVelocity = targetPos - transform.position;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        //Vector3 seekForce = desiredVelocity - velocity;
        return desiredVelocity - velocity;
    }

    protected Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }

    protected Vector3 Flee(Vector3 fleeTarget)
    {
        Vector3 desiredVelocity = transform.position - fleeTarget;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;
        return desiredVelocity - velocity;
    }

    protected Vector3 Flee(GameObject fleeTarget)
    {
        return Flee(fleeTarget.transform.position);
    }

    protected Vector3 StayInBounds(float secondsAhead)
    {
        Vector3 futurePos = CalcFuturePosition(secondsAhead);

        if(futurePos.x > worldBounds.x / 2f ||
           futurePos.x < -worldBounds.x / 2f ||
           futurePos.y > worldBounds.y / 2f ||
           futurePos.y < -worldBounds.y / 2f)
        {
            return Seek(Vector3.zero);
        }
        return Vector3.zero;
    }

    protected Vector3 Pursue(Agent pursuitTarget, float seconds)
    {
        Vector3 futurePos = pursuitTarget.CalcFuturePosition(seconds);
        return Seek(futurePos);
    }

    protected Vector3 Evade(Agent evadeTarget, float seconds)
    {
        Vector3 futurePos = evadeTarget.CalcFuturePosition(seconds);
        return Flee(futurePos);
    }

    protected Vector3 Alignment(Vector3 targetVelocity, bool clampToMaxSpeed = false)
    {
        if (clampToMaxSpeed)
        {
            targetVelocity = Vector3.ClampMagnitude(targetVelocity, maxSpeed);
        }
        return targetVelocity - velocity;
    }

    protected Vector3 Separate(Agent[] nearby, float radius)
    {
        Vector3 separateForce = Vector3.zero;

        for(int i = 0; i < nearby.Length; i++)
        {
            float dist = Vector2.Distance
                (transform.position, nearby[i].transform.position);

            float forceInverse = 1.0f - (dist / radius);

            separateForce += Flee(nearby[i].transform.position) * forceInverse;
        }

        separateForce = Vector3.ClampMagnitude(separateForce, maxSpeed);

        return separateForce;
    }

    protected Vector3 Wander(float jitter, float secondsAhead, float radius)
    {
        Vector3 futurePos = CalcFuturePosition(secondsAhead);

        jitter *= Time.fixedDeltaTime;

        wanderTarget.x += Random.Range(-jitter, jitter);
        wanderTarget.y += Random.Range(-jitter, jitter);

        wanderTarget = wanderTarget.normalized * radius;

        Vector3 targetInFront = futurePos + wanderTarget;

        return Seek(targetInFront);
    }

    public void OnDrawGizmosSelected()
    {
    }
}
