using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] private float maxSpeed;

    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected Vector3 steeringForce;


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
}
