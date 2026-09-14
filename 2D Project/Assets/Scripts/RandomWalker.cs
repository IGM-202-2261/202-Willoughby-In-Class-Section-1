using UnityEngine;

public class RandomWalker : MonoBehaviour
{
    [SerializeField]
    private float stepDistance = 0.1f;

    void Update()
    {
        float randValue = Random.Range(0.0f, 1.0f);
        Vector3 pos = transform.position;

        if (randValue < 0.4f)
        {
            pos.y += stepDistance;
        } 
        else if (randValue < 0.6)
        {
            pos.x += stepDistance;
        } 
        else if (randValue < 0.8)
        {
            pos.y -= stepDistance;
        } 
        else
        {
            pos.x -= stepDistance;
        }
        transform.position = pos;
    }
}
