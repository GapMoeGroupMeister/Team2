using UnityEngine;

public abstract class WeaponClass : MonoBehaviour
{
    protected float Cooltime(float cooltime)
    {
        cooltime -= Time.deltaTime;

        return cooltime;

        /*if (cooltime == 0) attacking = false;*/
    }

}



/*
    - �� :  ���� / /�����Ÿ� �߰�/ ���ݹ��� ����
    - â :  �ſ� ���� / /�����Ÿ� �߰� / ���ݹ��� ����
    - ���� : ���� / / �����Ÿ� �߰� / ���� ���� ŭ
    - �б�� :  ���� ���� / ���尩������ �߰����� /�����Ÿ� �߰�/���� ���� �ſ� ŭ (�ѹ��� ������ ����)
    - ���Ÿ� ����(Ȱ, ���� ��) : ���� / ���� �� �̼� ������ /�����Ÿ� ��/ ���� ���� ����
    - ���� : �տ� ���� ���� ��� ����
*/