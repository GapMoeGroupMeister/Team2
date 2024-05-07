using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarDayValue : MonoBehaviour
{
    [SerializeField] private int warday = 3;
    public int daycycle = 1;

    private void Awake()
    {
        if (warday == 0)
        {
            daycycle++;
        }
    }

    /*public void PressBtn()
    {
        warday--;
        wardayuUi.text = "남은 교전일 :" + warday;
    }*/
}
