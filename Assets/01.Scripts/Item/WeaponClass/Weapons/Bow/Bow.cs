using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bow : WeaponManager
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject bowPos;
    [SerializeField] private float _bowRange = 8.4f; // Ã¢ÀÇ 2¹èÂë
    private float _defaultBowRange = 8.4f;
    [SerializeField] private float _maxBowRange = 16.8f;
    [SerializeField] private float _bowAttackDamage = 8f;
    private float _defaultBowAttackDamage = 8f;
    [SerializeField] private float _maxBowAttackDamage = 64f;
    [SerializeField] private float _bowAttackSpeed = 2f;
    private bool pew = false;
    private bool isDrawing = false;

    private void Update()
    {
        if (_bowRange >= _maxBowRange || _bowAttackDamage >= _maxBowAttackDamage)
        {
            pew = true;
            _bowRange = _defaultBowRange;
            _bowAttackDamage = _defaultBowAttackDamage;
            Instantiate(arrowPrefab);
        }
    }

    private void OnCharge(InputValue value)
    {
        if (value.isPressed||pew == false)
        {
            isDrawing = true;
            _bowRange += Time.deltaTime;
            _bowAttackDamage += Time.deltaTime * 8;
        }
        else if (isDrawing == true)
        {
            isDrawing = false;
            pew = true;
            Instantiate(arrowPrefab);
        }

    }
}
