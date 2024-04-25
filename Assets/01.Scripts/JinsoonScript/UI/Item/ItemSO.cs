using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{
    public int id;
    [Header("Ok For Korean")]
    public string itemName;
    public string itemExplain;
    public int maxAmountInSlot;

    [Space(16)]
    public Sprite itemImage;
    public GameObject itemPf;
    public GameObject itemSell;

    [Header("Size Of Horizontal And Vertical")]
    public Vector2Int itemSize;
}