using UnityEngine;

public class FramerateTest : MonoBehaviour
{
    [SerializeField, Range(10, 100)]
    private int targetFrameRate = 60;

    void Update()
    {
        Application.targetFrameRate = targetFrameRate;
    }
}
