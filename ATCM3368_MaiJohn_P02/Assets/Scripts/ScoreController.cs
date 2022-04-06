using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    [SerializeField] UnityEvent UpdateScore;

    [SerializeField] int startingScore = 0;
    [SerializeField] int minimumScore = 0;

    int currentScore;

    public int GetCurrentScore => currentScore;

    private void Awake()
    {
        currentScore = startingScore;
    }

    public void IncreaseScore(int scoreIncrease)
    {
        currentScore += scoreIncrease;
    }

    public void DecreaseScore(int scoreDecrease)
    {
        currentScore -= scoreDecrease;

        if (currentScore < minimumScore)
        {
            currentScore = minimumScore;
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
