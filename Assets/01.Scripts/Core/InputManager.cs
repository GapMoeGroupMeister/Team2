using System;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
   public event Action AttackEvent;
   public event Action<Vector2> MoveEvent;
   
   private void Update()
   {
      OnAttack();
      OnMove();
   }

   private void OnAttack()
   {
      if (Input.GetMouseButtonDown(0))
      {
         AttackEvent?.Invoke();
      }
   }

   private void OnMove()
   {
      Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      MoveEvent?.Invoke(dir);
   }
}
