using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionUsing : MonoBehaviour
{
    private int nowPosion = 5;
    private bool canEat = true;
    private bool cooltimeDone = true;
    private bool coolDown = false;
    private float coolTime = 5;
    private void Update()
    {
        if (cooltimeDone == true)
        {
            if (canEat == true && Input.GetKeyDown(KeyCode.Space))
            {
                coolDown = true;
                nowPosion--;
            }
            if (nowPosion <= 0)
            {
                canEat = false;
            }
        }
        if (coolDown == true)
        {
            cooltimeDone = false;
            coolTime -= Time.deltaTime;
            if (coolTime <= 0)
            {
                cooltimeDone = true;
                coolTime = 5f;
                coolDown = false;
            }
        }
    }
}
