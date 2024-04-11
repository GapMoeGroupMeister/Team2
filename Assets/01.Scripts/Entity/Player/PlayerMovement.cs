using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : Player
{
    protected void Update()
    {
        Move();
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 MoveDir = new Vector3(horizontal, vertical, 0).normalized;
        

        if (Input.GetKey(KeyCode.LeftShift) && !(currentStamina <= 0))
        {
            increaseSpeed += currentStamina / acceleration * Time.deltaTime;
            currentStamina -= 0.996f * Time.deltaTime;
            movespeed += increaseSpeed;
        }
        else if (!(currentStamina >= fullStamina) && !Input.GetKey(KeyCode.LeftShift))
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
