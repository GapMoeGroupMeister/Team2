using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowMuchDefeat : MonoBehaviour
{
    [SerializeField] private static int defeat = 0;
    [SerializeField] private Text _defeatUI;


    private void Awake()
    {
        _defeatUI.text = "���� Ƚ�� : " + defeat;
    }

    public void pressBtn()
    {

        defeat++;
        _defeatUI.text = "���� Ƚ�� : " + defeat;
    }
    private void Update()
    {
        //ü�� �ҷ��ͼ� 0�̸� defeat ����
        //�ð��� ��Ƽ���� ���� �� ���̸� defeat �Լ� �ʱ�ȭ
    }
}
