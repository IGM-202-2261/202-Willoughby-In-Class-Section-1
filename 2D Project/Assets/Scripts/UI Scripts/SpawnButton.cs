using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] private Button spawnButton;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Slider spawnSlider;
    [SerializeField] private BallSpawner ballSpawner;

    int numToSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(spawnSlider != null)
        {
            spawnSlider.onValueChanged.AddListener(OnSliderMoved);
        }
    }

    private void OnSliderMoved(float newValue)
    {
        numToSpawn = (int)newValue;

        if(buttonText != null)
        {
            buttonText.text = $"Spawn {numToSpawn} balls!";
        }
    }
}
