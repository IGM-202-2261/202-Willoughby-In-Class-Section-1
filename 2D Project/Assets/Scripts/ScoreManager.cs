using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public static ScoreManager Instance { get; private set; }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        score = 0;
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;

        Debug.Log(score);
    }
}
