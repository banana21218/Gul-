using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public int credits;
    public void ButtonMoveScene()
    {
        SceneManager.LoadScene(credits);
    }
}
