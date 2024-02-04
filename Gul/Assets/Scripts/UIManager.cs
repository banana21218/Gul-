using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text foodNum;
    [SerializeField] TMP_Text pointTxt;
    [SerializeField] TMP_Text endScore;

    public int points;

    public void updateFood(int food)
    {
        //GameObject.Find("FoodNum");
        foodNum.SetText(food.ToString());
    }

    public void updatePoints()
    {
        pointTxt.SetText(points.ToString());
    }
    //
    public TMP_Text TimerText;
    public bool playing = true;
    public float Timer = 600;

    public bool gamePaused;
    public GameObject pausedMenu;
    public GameObject howto;
    public GameObject endScreen;

    private void Start()
    {
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        Timer--;
        yield return new WaitForSeconds(1);
        TimerText.text = Timer.ToString() + "s";
        if (Timer != 0)
        {
            StartCoroutine(timer());
        }
        else if (Timer == 0)
        {
            endScreen.SetActive(true);
            endScore.SetText(points.ToString() + " Points!");
        }
    }

    public void pause(InputAction.CallbackContext context)
    {
        Debug.Log("Paused");
        if (context.performed)
        {
            if(gamePaused == false)
            {
                startPause();
                gamePaused = true;
            }
            else
            {
                endPause();
                gamePaused = false;
            }
        }
    }

    private void startPause()
    {
        Time.timeScale = 0f;
        pausedMenu.SetActive(true);
    }

    public void endPause()
    {
        Debug.Log("Unpaused");
        Time.timeScale = 1.0f;
        pausedMenu.SetActive(false);
        closeHowTo();
    }

    public void openHowTo()
    {
        howto.SetActive(true);
    }

    public void closeHowTo()
    {
        howto.SetActive(false);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void replay()
    {
        SceneManager.LoadScene(1);
    }
}
