using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject howTo;

    public void returnToMenu() 
    {
        howTo.SetActive(false);
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void openCredits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void goToHowto()
    {
        credits.SetActive(false);
        mainMenu.SetActive(false);
        howTo.SetActive(true);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
