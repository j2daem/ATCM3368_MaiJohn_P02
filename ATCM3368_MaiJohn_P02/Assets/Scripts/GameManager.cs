using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] MenuManager menuManager = null;

    private MenuState currentMenuState;

    private void Start()
    {
        currentMenuState = MenuState.Main;
    }

    public enum MenuState
    {
        Main,
        Credits,
        Reset,
        Quit
    }

    public void MenuToOpen(string _menuName)
    {
        switch (_menuName)
        {
            case "Main":
            case "main":
                currentMenuState = MenuState.Main;
                Debug.Log("Current menu state: Main");
                break;

            case "Credits":
            case "credits":
                currentMenuState = MenuState.Credits;
                Debug.Log("Current menu state: Credits");
                break;

            case "Reset":
            case "reset":
                currentMenuState = MenuState.Reset;
                Debug.Log("Current menu state: Reset");
                break;

            case "Quit":
            case "quit":
                currentMenuState = MenuState.Quit;
                Debug.Log("Current menu state: Quit");
                break;

            default:
                Debug.Log("Invalid menu state.");
                break;
        }
        menuManager.ChangeMenuTo(currentMenuState);
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }
}