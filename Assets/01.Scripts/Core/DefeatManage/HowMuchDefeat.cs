using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowMuchDefeat : MonoBehaviour
{
    [SerializeField] public int defeat = 0;
    [SerializeField] private Text _defeatUI;


    /*private void Awake()
    {
        _defeatUI.text = "패전 횟수 : " + defeat;
    }

    public void pressBtn()
    {

        defeat++;
        _defeatUI.text = "패전 횟수 : " + defeat;
    }

    public void Reset()
    {
        defeat = 0;
        _defeatUI.text = "패전 횟수 : " + defeat;
    }*/

    private void Update()
    {
        //체력 불러와서 0이면 defeat 증가
        //시간을 버티던가 적을 다 죽이면 defeat 함수 초기화
    }
}
