using System;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
   private GameManager _gameManager;
   private Transform _playerTrm;
   public event Action AttackEvent;
   public event Action<Vector2> MoveEvent;
   public event Action<Vector2> AttackDirectionEvent;
   public event Action ChangeWeaponEvent;
   
   private void Awake()
   {
      _gameManager = GameManager.Instance;
      _playerTrm = _gameManager.PlayerController.transform; 
   }

   private void Update()
   {
      OnAttack();
      OnMove();
      OnAttackDirection();
      OnChangeWeapon();
   }

   private void OnAttack()
   {
      if (Input.GetMouseButtonDown(0))
      {
         AttackEvent?.Invoke();
      }
   }

   private void OnAttackDirection()
   {
      Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _playerTrm.position).normalized;
      AttackDirectionEvent?.Invoke(dir);
   }
   
   private void OnMove()
   {
      Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      MoveEvent?.Invoke(dir);
   }

   private void OnChangeWeapon()
   {
      if(Input.GetKeyDown(KeyCode.LeftShift))
         ChangeWeaponEvent?.Invoke();
   }
}
