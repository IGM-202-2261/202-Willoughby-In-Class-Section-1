using UnityEngine;

public class Week5Tests : MonoBehaviour
{
    [SerializeField] Transform targetPos;
    [SerializeField] float speed;

    [SerializeField] Vector2 vectorA;
    [SerializeField] Vector2 vectorB;

    void Update()
    {
        // A - B = Vector from B to A
        Vector3 direction = targetPos.position - transform.position;
        
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {


        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector2.zero, vectorA);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Vector2.zero, vectorB);

        Gizmos.color = Color.yellow;
        //Vector2 aPlusB = vectorA + vectorB;
        //Gizmos.DrawLine(Vector2.zero, aPlusB);

        //Vector2 aMinusB = vectorB - vectorA ;
        //Gizmos.DrawLine(Vector2.zero, aMinusB);
        Gizmos.DrawLine(Vector2.zero, vectorA / 2);

        Debug.Log(vectorA.magnitude);

        Debug.Log(vectorA.normalized);
        vectorA.Normalize();
        Debug.Log(vectorA);
    }
}
