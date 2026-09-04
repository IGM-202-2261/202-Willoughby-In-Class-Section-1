using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer ballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer ballRenderer = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        //ball.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        ballRenderer.color = new Color(
                Random.Range(0.2f, 1.0f),
                Random.Range(0.2f, 1.0f),
                Random.Range(0.2f, 1.0f)
            );

        Destroy(ballRenderer.gameObject);
    }
}
