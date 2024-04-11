using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponClass : MonoBehaviour
{
    public abstract void Attack();
}



/*
    - 검 :  빠름 / /사정거리 중간/ 공격범위 보통
    - 창 :  매우 빠름 / /사정거리 중간 / 공격범위 작음
    - 도끼 : 보통 / / 사정거리 중간 / 공격 범위 큼
    - 둔기류 :  공속 느림 / 중장갑병에게 추가피해 /사정거리 중간/공격 범위 매우 큼 (한바퀴 돌듯이 공격)
    - 원거리 무기(활, 석궁 등) : 보통 / 조준 시 이속 느려짐 /사정거리 김/ 공격 범위 작음
    - 방패 : 앞에 오는 공격 방어 가능
*/