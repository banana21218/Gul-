using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        quit();
    }
    public void quit()
    {

        Application.Quit();
    }
}
