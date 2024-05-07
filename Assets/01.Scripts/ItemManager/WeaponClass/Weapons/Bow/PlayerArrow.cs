using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    private void Update()
    {
        transform.position += moveDir * _arrowSpeed * Time.deltaTime;
    }
}
