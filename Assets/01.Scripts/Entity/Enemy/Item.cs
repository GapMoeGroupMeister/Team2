using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _inventorySize;
    [SerializeField] private int _inventoryCount;
}
