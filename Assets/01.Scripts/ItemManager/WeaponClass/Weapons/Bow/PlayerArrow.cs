using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : WeaponManager
{
    [SerializeField] private float _arrowSpeed = 100f;

    private void Update()
    {
        transform.position += moveDir * _arrowSpeed * Time.deltaTime;
    }
}
