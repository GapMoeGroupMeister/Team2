using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowMuchDefeat : MonoBehaviour
{
    [SerializeField] public int defeat;

    public void pressBtn()
    {
        defeat++;
    }

    public void Reset()
    {
        defeat = 0;
    }

    private void Update()
    {
        //체력 불러와서 0이면 defeat 증가
        //시간을 버티던가 적을 다 죽이면 defeat 함수 초기화
    }
}
