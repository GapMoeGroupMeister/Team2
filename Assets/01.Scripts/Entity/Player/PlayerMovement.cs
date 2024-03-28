using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float movespeed = 5;
    private float currentStamina = 20;
    private float fullStamina = 20;
    private float increaseSpeed;
    private float acceleration = 3.4f;
    private float deceleration = 5.5f;
    private float cureStamina = 0.83f;
    protected string tagValue;

    private void Update()
    {
        Move();
    }
    public void SetTagValue(string newTagValue)
    {
        tagValue = newTagValue;
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");




        vertical = Input.GetAxisRaw("Vertical");

        Vector3 MoveDir = new Vector3(horizontal, vertical, 0);
        MoveDir.Normalize();
        

        if (Input.GetKey(KeyCode.LeftShift) && !(currentStamina <= 0))
        {
            increaseSpeed += currentStamina / acceleration * Time.deltaTime;
            currentStamina -= 0.996f * Time.deltaTime;
            movespeed += increaseSpeed;
        }
        else if (!(currentStamina >= fullStamina) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            currentStamina += cureStamina * Time.deltaTime;
        }


        transform.position += MoveDir * movespeed * Time.deltaTime;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            movespeed -= increaseSpeed;
            increaseSpeed -= fullStamina / deceleration * Time.deltaTime;
        }

        if (increaseSpeed <= 0)
        {
            increaseSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || currentStamina <= 0)
        {
            increaseSpeed = 0;
        }
    }

    


}
