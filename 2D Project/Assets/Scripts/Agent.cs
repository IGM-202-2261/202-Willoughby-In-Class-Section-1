using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] private float maxSpeed;

    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected Vector3 steeringForce;

    [SerializeField] protected Vector3 worldBounds;


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

    public void OnDrawGizmosSelected()
    {
    }
}
