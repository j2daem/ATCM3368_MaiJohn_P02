using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;

    int _currentScore;

    private void Update()
    {
        //Increase score
        //TODO: Replace with real implementation later
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }

        //Exit level
        //TODO: Bring up pop-up menu for navigation
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel();
        }
    }

    public void ExitLevel()
    {
        //Load high score from player prefs; create if non-existent
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        //Compare current score to high score
        if (_currentScore > highScore)
        {
            //Save current score as new high score
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }

        //Return to main menu and load a new level
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore(int scoreIncrease)
    {
        //Increase score
        _currentScore += scoreIncrease;
        //Update score display to show new score
        _currentScoreTextView.text = _currentScore.ToString();
    }
}
