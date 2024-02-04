using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.Android;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text foodNum;
    public void updateFood(int food)
    {
        //GameObject.Find("FoodNum");
        foodNum.SetText(food.ToString());
    }
    //
    public TMP_Text TimerText;
    public bool playing = true;
    private float Timer = 600;

    public bool gamePaused;
    public GameObject pausedMenu;

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
    }


}
