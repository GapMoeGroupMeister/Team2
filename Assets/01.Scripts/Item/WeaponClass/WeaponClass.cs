using UnityEngine;

public abstract class WeaponClass : MonoBehaviour
{
    public abstract int WeaponDamage(float damage);
    public abstract int WeaponCooltime(int cooltime);


}



/*
    - �� :  ���� / /�����Ÿ� �߰�/ ���ݹ��� ����
    - â :  �ſ� ���� / /�����Ÿ� �߰� / ���ݹ��� ����
    - ���� : ���� / / �����Ÿ� �߰� / ���� ���� ŭ
    - �б�� :  ���� ���� / ���尩������ �߰����� /�����Ÿ� �߰�/���� ���� �ſ� ŭ (�ѹ��� ������ ����)
    - ���Ÿ� ����(Ȱ, ���� ��) : ���� / ���� �� �̼� ������ /�����Ÿ� ��/ ���� ���� ����
    - ���� : �տ� ���� ���� ��� ����
*/