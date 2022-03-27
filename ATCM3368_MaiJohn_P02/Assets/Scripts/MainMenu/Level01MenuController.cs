using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01MenuController : MonoBehaviour
{
    [Header("Menu Controller Intialization")]
    [SerializeField] MenuManager menuManager = null;
    [SerializeField] MouseLook mouseLook = null;
    [SerializeField] GameObject pausedBackground = null;
    [SerializeField] ScoreController scoreController = null;
    [SerializeField] Slider volumeSlider = null;

    bool _paused;

    private void Awake()
    {
        // Initialize volume slider values to correspond with AudioManager
        volumeSlider.value = global::AudioManager.Instance._audioSource.volume;
        volumeSlider.maxValue = global::AudioManager.Instance._audioSource.maxDistance;
        volumeSlider.maxValue = global::AudioManager.Instance._audioSource.minDistance;
    }

    private void Update()
    {
        // Press "ESC" to open the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused)
            {
                PauseLevel();
            }

            else
            {
                ResumeLevel();
            }
        }
    }

    public void AdjustVolume()
    {
        global::AudioManager.Instance.AdjustVolume(volumeSlider.value);
        Debug.Log("New volume: " + volumeSlider.value.ToString());
    }

    public void ExitLevel()
    {
        scoreController.CheckHighScore();

        //Return to main menu and load a new level
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseLevel()
    {
        pausedBackground.SetActive(true);
        menuManager.ChooseMenuToOpen("Paused");
        _paused = true;

        Cursor.lockState = CursorLockMode.None;
        mouseLook.enabled = false;
    }

    public void ResumeLevel()
    {
        pausedBackground.SetActive(false);
        menuManager.ChooseMenuToOpen("Closed");
        _paused = false;

        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level01");
    }
}
