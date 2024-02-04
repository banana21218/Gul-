using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameObject angry;

    public GameObject angryFace;
    public GameObject happyFace;

    private bool isAngry = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Poop")
        {
            if (isAngry == false)
            {
                Debug.Log("Pooped");
                angry.SetActive(true);
                angryFace.SetActive(true);
                happyFace.SetActive(false);
                for(int i = 0; i < 25; i++) 
                {
                    GameObject.Find("GameManager").GetComponent<UIManager>().points++;
                }
                GameObject.Find("GameManager").GetComponent<UIManager>().updatePoints();
            }
        }
    }
}
