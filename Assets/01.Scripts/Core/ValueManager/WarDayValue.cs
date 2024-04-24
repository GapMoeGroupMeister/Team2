using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarDayValue : MonoBehaviour
{
    public Text wardayuUi;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    [SerializeField] private int warday = 3;

    public void PressBtn()
    {
        warday--;
        wardayuUi.text = "���� ������ :" + warday;
    }
}
