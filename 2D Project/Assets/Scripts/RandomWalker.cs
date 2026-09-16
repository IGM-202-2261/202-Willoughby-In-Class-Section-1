using System;
using UnityEngine;

public class RandomWalker : MonoBehaviour
{
    [SerializeField]
    private float stepDistance = 0.1f;

    [SerializeField]
    private SpriteRenderer squarePrefab;

    [SerializeField]
    private float noiseScale = 1.0f;

    float timer = 0.0f;

    [SerializeField]
    private float actionInterval = 4.0f;

    [SerializeField]
    private Transform startPoint;

    [SerializeField]
    private Transform endPoint;

    void Update()
    {
        timer += Time.deltaTime;

        transform.position = Vector2.Lerp(startPoint.position, endPoint.position, timer / 10.0f);
    }
    /*
     * Instantiate(squarePrefab, pos, Quaternion.identity).color = Color.black;
        pos.x += stepDistance;
        pos.y = Mathf.PerlinNoise1D((pos.x * noiseScale) + 8) * 4f;
     * 
     */


    /*
        float randValue = Random.Range(0.0f, 1.0f);
     *         if (randValue < 0.4f)
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
     */
}
