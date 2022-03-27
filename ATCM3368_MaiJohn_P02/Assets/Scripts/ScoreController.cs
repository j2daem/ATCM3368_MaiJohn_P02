using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    [SerializeField] UnityEvent UpdateScore;

    [SerializeField] int StartingScore = 0;
    [SerializeField] int MinimumScore = 0;

    int currentScore;

    private void Update()
    {
        // For testing high score; remove later
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
            Debug.Log("Current score: " + currentScore);
        }
    }

    public int GetCurrentScore => currentScore;

    private void Awake()
    {
        currentScore = StartingScore;
    }

    public void IncreaseScore(int scoreIncrease)
    {
        currentScore += scoreIncrease;
    }

    public void DecreaseScore(int scoreDecrease)
    {
        currentScore -= scoreDecrease;

        if (currentScore < 0)
        {
            currentScore = 0;
        }
    }

    public void CheckHighScore()
    {
        //Load high score from player prefs; create if non-existent
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        //Compare current score to high score
        if (currentScore > highScore)
        {
            //Save current score as new high score
            PlayerPrefs.SetInt("HighScore", currentScore);
            Debug.Log("New high score: " + currentScore);
        }
    }
}
