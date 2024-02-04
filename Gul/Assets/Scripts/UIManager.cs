using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text foodNum;
    public void updateFood(int food)
    {
        //GameObject.Find("FoodNum");
        foodNum.SetText(food.ToString());
    }
}
