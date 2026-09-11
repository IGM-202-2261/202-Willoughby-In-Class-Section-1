using UnityEngine;
using UnityEngine.InputSystem;

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

    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector2 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            SpawnBallAtPosition(mousePosInWorldSpace);
        }
    }

    void SpawnBallAtPosition(Vector3 pos)
    {
        SpriteRenderer ballRenderer = Instantiate(ballPrefab, pos, Quaternion.identity);
        ballRenderer.color = new Color(
                Random.Range(0.2f, 1.0f),
                Random.Range(0.2f, 1.0f),
                Random.Range(0.2f, 1.0f)
            );
    }
}
