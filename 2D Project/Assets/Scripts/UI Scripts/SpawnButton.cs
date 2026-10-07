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


    void Start()
    {
        if(spawnSlider != null)
        {
            spawnSlider.onValueChanged.AddListener(OnSliderMoved);
            OnSliderMoved(spawnSlider.value);
        }
        if(spawnButton != null)
        {
            spawnButton.onClick.AddListener(OnSpawnClick);
        }
    }

    void OnDestroy()
    {
        if(spawnSlider != null)
        {
            spawnSlider.onValueChanged.RemoveListener(OnSliderMoved);
        }
        if(spawnButton != null)
        {
            spawnButton.onClick.RemoveListener(OnSpawnClick);
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

    private void OnSpawnClick()
    {
        ballSpawner.SpawnBallsAtCenter(numToSpawn);
    }
}
