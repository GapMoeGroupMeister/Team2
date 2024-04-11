using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    void Update()
    {
        float speed = 5f;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(h, 0, 0);
        Vector3 moveWir = new Vector3(0, v, 0);

        transform.position += moveDir * speed * Time.deltaTime;
        transform.position += moveWir * speed * Time.deltaTime;

    }
}
