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
        //ü�� �ҷ��ͼ� 0�̸� defeat ����
        //�ð��� ��Ƽ���� ���� �� ���̸� defeat �Լ� �ʱ�ȭ
    }
}
