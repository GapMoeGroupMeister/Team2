using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : WeaponManager
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject bowPos;

    [SerializeField] private float _bowRange = 8.4f; // Ã¢ÀÇ 2¹èÂë
    [SerializeField] private float _bowAttackDamage = 8f;
    [SerializeField] private float _bowAttackSpeed = 2f;

    private void Update()
    {
        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = bowPos.transform.position;
    }
}
