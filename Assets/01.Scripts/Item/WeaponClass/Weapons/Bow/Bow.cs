using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : WeaponManager
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject bowPos;
    [SerializeField] private float _bowRange = 8.4f; // Ã¢ÀÇ 2¹èÂë
    [SerializeField] private float _maxBowRange = 16.8f;
    [SerializeField] private float _bowAttackDamage = 8f;
    [SerializeField] private float _maxBowAttackDamage = 32f;
    [SerializeField] private float _bowAttackSpeed = 2f;
    private bool pew = false;

    private void Update()
    {
        if (_bowRange <= _maxBowRange || _bowAttackDamage <= _maxBowAttackDamage)
        {
            pew = true;
        }

        
        
    }
}
