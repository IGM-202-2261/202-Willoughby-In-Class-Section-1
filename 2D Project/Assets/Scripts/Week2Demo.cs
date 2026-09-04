using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    private int counter = 0;

    [SerializeField]
    private SpriteRenderer sRend;

    [SerializeField]
    private Color overlapColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Hello World");
        //sRend = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sRend.color = overlapColor;
        //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.purple;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sRend.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 localPos = transform.localPosition;
        //localPos.x += 0.01f;
        //transform.localPosition = localPos;
    }


}
