using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] Text CurrentScoreText = null;
    [SerializeField] ScoreController scoreController = null;

    public void UpdateScore()
    {
        CurrentScoreText.text = scoreController.GetCurrentScore.ToString();
    }
}
