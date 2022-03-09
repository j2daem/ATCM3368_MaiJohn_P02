using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject losePanel = null;
    [SerializeField] GameObject winPanel = null;
    [SerializeField] GameObject pausePanelBackground = null;
    [SerializeField] GameObject pausePanel = null;
    [SerializeField] GameObject restartPanel = null;
    [SerializeField] GameObject settingsPanel = null;
    [SerializeField] GameObject exitPanel = null;

    GameState currentGameState;

    private void Start()
    {
        currentGameState = GameState.Closed;
        pausePanelBackground.SetActive(false);
    }

    public enum GameState
    {
        Closed,
        Lose,
        Win,
        Pause,
        Restart,
        Settings,
        Exit
    }
    public void ResumeGame()
    {
        currentGameState = GameState.Closed;
        CloseMenu();
        pausePanelBackground.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoseGame()
    {
        currentGameState = GameState.Lose;
        CloseMenu();
        losePanel.SetActive(true);
    }

    public void WinGame()
    {
        currentGameState = GameState.Win;
        CloseMenu();
        winPanel.SetActive(true);
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;

        currentGameState = GameState.Pause;
        CloseMenu();
        pausePanelBackground.SetActive(true);
        pausePanel.SetActive(true);
    }

    public void RestartGame()
    {
        currentGameState = GameState.Restart;
        CloseMenu();
        restartPanel.SetActive(true);
    }

    public void OpenSettings()
    {
        currentGameState = GameState.Settings;
        CloseMenu();
        settingsPanel.SetActive(true);
    }

    public void OpenExit()
    {
        currentGameState = GameState.Exit;
        CloseMenu();
        exitPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
        restartPanel.SetActive(false);
        settingsPanel.SetActive(false);
        exitPanel.SetActive(false);
    }
}
