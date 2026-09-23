using UnityEngine;

public class Week5Tests : MonoBehaviour
{
    [SerializeField] Vector2 vectorA;
    [SerializeField] Vector2 vectorB;
    void Start()
    {
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
    }
}
