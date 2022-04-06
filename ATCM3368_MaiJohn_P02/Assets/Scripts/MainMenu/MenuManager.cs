using System;
using UnityEngine;

public enum MenuState
{
    Closed, Credits, Exit, Lose, Main, Paused, Quit, Reset, Restart, Settings, Win
}

public class MenuManager : MonoBehaviour
{
    // Get menu panels to enable/disable
    [SerializeField] AssignMenuState[] Menus = new AssignMenuState[5];

    //Keep track which state is active
    private MenuState _currentMenuState;

    //Menu choices (choices limited through enums)
    public void ChooseMenuToOpen(string _menuName)
    {
        MenuState _menuState = (MenuState)Enum.Parse(typeof(MenuState), _menuName);

        switch (_menuState)
        {
            case MenuState.Closed:
                _currentMenuState = MenuState.Closed;
                Debug.Log("Closing menus");
                CloseMenus();
                return;

            case MenuState.Credits:
                _currentMenuState = MenuState.Credits;
                Debug.Log("Current menu state: Credits");
                break;

            case MenuState.Exit:
                _currentMenuState = MenuState.Exit;
                Debug.Log("Current menu state: Exit");
                break;

            case MenuState.Lose:
                _currentMenuState = MenuState.Lose;
                Debug.Log("Current menu state: Lose");
                break;

            case MenuState.Main:
                _currentMenuState = MenuState.Main;
                Debug.Log("Current menu state: Main");
                break;

            case MenuState.Paused:
                _currentMenuState = MenuState.Paused;
                Debug.Log("Current menu state: Paused");
                break;

            case MenuState.Quit:
                _currentMenuState = MenuState.Quit;
                Debug.Log("Current menu state: Quit");
                break;

            case MenuState.Reset:
                _currentMenuState = MenuState.Reset;
                Debug.Log("Current menu state: Reset");
                break;

            case MenuState.Restart:
                _currentMenuState = MenuState.Restart;
                Debug.Log("Current menu state: Restart");
                break;

            case MenuState.Settings:
                _currentMenuState = MenuState.Settings;
                Debug.Log("Current menu state: Settings");
                break;

            case MenuState.Win:
                _currentMenuState = MenuState.Win;
                Debug.Log("Current menu state: Win");
                break;

            default:
                Debug.Log("Invalid menu state. Closing menus");
                _currentMenuState = MenuState.Closed;
                CloseMenus();
                return;
        }
        ChangeMenuTo(_currentMenuState);
    }

    private void ChangeMenuTo(MenuState _menuState)
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            if (Menus[i].GetMenuState == _menuState)
            {
                Menus[i].gameObject.SetActive(true);
                Debug.Log("Activated menu: " + i + " of menu array.");
            }

            else
            {
                Menus[i].gameObject.SetActive(false);
            }
        }
    }

    private void CloseMenus()
    {
        for (int i = 0; i < Menus.Length; i++)
        {
                Menus[i].gameObject.SetActive(false);
        }
    }
}