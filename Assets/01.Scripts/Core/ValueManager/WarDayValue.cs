using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarDayValue : MonoBehaviour
{
    [SerializeField] private int warday;
    public int daycycle = 1;

    private void Awake()
    {
        warday = PlayDataManager.Instance.playData._fightDay;
    }

    private void Update()
    {
        if (warday == 0)
        {
            daycycle++;
            PlayDataManager.Instance.playData._fightDay = 3;
        }
    }

    /*public void PressBtn()
    {
        warday--;
        wardayuUi.text = "남은 교전일 :" + warday;
    }*/
}
