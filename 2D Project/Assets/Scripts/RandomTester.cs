using UnityEngine;

public class RandomTester : MonoBehaviour
{
    [SerializeField]
    private GameObject squarePrefab;
    [SerializeField]
    private Vector2 screenBounds;
    [SerializeField]
    private int numSquares = 10;

    void Start()
    {
        for(int i = 0; i < numSquares; i++)
        {
            Vector2 randomPos = new Vector2(
                    Gaussian(0, screenBounds.x / 4.0f),
                    Gaussian(0, screenBounds.y / 4.0f)
                );

            Instantiate(squarePrefab, randomPos, Quaternion.identity);
        }
    }

    float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);
        float gaussValue =
                 Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
                 Mathf.Sin(2.0f * Mathf.PI * val2);
        return mean + stdDev * gaussValue;
    }

}
