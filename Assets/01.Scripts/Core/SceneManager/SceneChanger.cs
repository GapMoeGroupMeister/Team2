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
---����, ���� �ؾ� �� ��---
    �󸶳� ���� �ߴ°�
    �� �����ΰ� (Ư���� ���� �䱸ġ ����)
    ȣ������ ���ΰ� << �̱� �� ��� ����
    Ŭ���� ����, ���� ���� ��
    ���� ������
     */
}
