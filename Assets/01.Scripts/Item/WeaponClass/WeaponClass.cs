using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponClass : MonoBehaviour
{
    public abstract void Attack();
}



/*
    - �� :  ���� / /�����Ÿ� �߰�/ ���ݹ��� ����
    - â :  �ſ� ���� / /�����Ÿ� �߰� / ���ݹ��� ����
    - ���� : ���� / / �����Ÿ� �߰� / ���� ���� ŭ
    - �б�� :  ���� ���� / ���尩������ �߰����� /�����Ÿ� �߰�/���� ���� �ſ� ŭ (�ѹ��� ������ ����)
    - ���Ÿ� ����(Ȱ, ���� ��) : ���� / ���� �� �̼� ������ /�����Ÿ� ��/ ���� ���� ����
    - ���� : �տ� ���� ���� ��� ����
*/