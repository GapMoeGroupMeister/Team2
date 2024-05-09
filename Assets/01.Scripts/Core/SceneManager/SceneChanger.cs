using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private LoveCalcul _love;

    private void Awake()
    {
        _love = GetComponent<LoveCalcul>();
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("RSJScene");
        PlayDataManager.Instance.playData._loveValue = _love._value;
        PlayDataManager.Instance.SavePlayData();
    }

    /*
---전달, 저장 해야 할 것---
    얼마나 패전 했는가
    몇 일차인가 (특정일 마다 요구치 증가)
    호감도가 얼마인가 << 싱글 톤 사용 예정
    클리어 조건, 모은 물자 수
    남은 교전일
     */
}
