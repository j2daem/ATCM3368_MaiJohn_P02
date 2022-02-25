using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel = null;
    [SerializeField] GameObject creditsMenuPanel = null;
    [SerializeField] GameObject resetMenuPanel = null;
    [SerializeField] GameObject quitMenuPanel = null;

    GameObject currentMenu = null;

    public void ChangeMenuTo(GameManager.MenuState _menuName)
    {
        switch (_menuName)
        {
            case GameManager.MenuState.Main:
                mainMenuPanel.SetActive(true);
                creditsMenuPanel.SetActive(false);
                resetMenuPanel.SetActive(false);
                quitMenuPanel.SetActive(false);
                break;

            case GameManager.MenuState.Credits:
                creditsMenuPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                resetMenuPanel.SetActive(false);
                quitMenuPanel.SetActive(false);
                break;

            case GameManager.MenuState.Reset:
                resetMenuPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                creditsMenuPanel.SetActive(false);
                quitMenuPanel.SetActive(false);
                break;

            case GameManager.MenuState.Quit:
                quitMenuPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                creditsMenuPanel.SetActive(false);
                resetMenuPanel.SetActive(false);
                break;
        }
    }
}