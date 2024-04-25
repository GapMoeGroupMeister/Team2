using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : WeaponManager
{
    

    private void Update()
    {
        transform.position += moveDir * _arrowSpeed * Time.deltaTime;
    }
}
