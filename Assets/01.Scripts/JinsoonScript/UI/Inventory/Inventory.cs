using EasySave;
using EasySave.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    #region InventoryInformation

    public InventorySO inventorySO;
    public GameObject slotPf;
    private Transform slots;
    [SerializeField] private List<ItemSO> itemSet = new List<ItemSO>();
    [SerializeField] private Transform itemParent;

    public string inventoryName { get; private set; }
    public Vector2Int inventorySize { get; private set; }

    #endregion

    private string path;

    public Slot[,] inventorySlots { get; private set; }

    private void Awake()
    {
        inventoryName = inventorySO.InventoryName;
        inventorySize = inventorySO.inventorySize;
        slots = transform.Find("Slots");

        inventorySlots = new Slot[inventorySize.x, inventorySize.y];

        for (int i = 0; i < inventorySize.y; i++)
        {
            for (int j = 0; j < inventorySize.x; j++)
            {
                Slot slot = Instantiate(slotPf, slots).GetComponent<Slot>();
                slot.SetOwner(this, new Vector2Int(j, i));
                inventorySlots[j, i] = slot;
            }
        }
    }

    private void Start()
    {
        StartCoroutine(DelayLoad());
    }

    private IEnumerator DelayLoad()
    {
        yield return null;
        Load();
    }

    [SerializeField] private ItemSO testItem;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SetItem(testItem);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position">Position of item's bottom left</param>
    /// <param name="item"></param>
    public void SetItem(ItemSO item)
    {
        Item itemPf = Instantiate(item.itemPf, itemParent).GetComponent<Item>();
        itemPf.Init(item);

        for (int i = 0; i < inventorySize.y; i++)
        {
            for (int j = 0; j < inventorySize.x; j++)
            {
                if (CanInsertItem(j, i, item.itemSize.x, item.itemSize.y))
                {
                    inventorySlots[j, i].SetItem(itemPf, true);
                    return;
                }
            }
        }
    }

    private bool CanInsertItem(int posX, int posY, int sizeX, int sizeY)
    {
        for (int i = 0; i < sizeY; i++)
        {
            for (int j = 0; j < sizeX; j++)
            {
                if (posX + j >= inventorySize.x || posY + i >= inventorySize.y
                    || inventorySlots[posX + j, posY + i].assignedItem != null)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void Save()
    {
        InventorySave saves = new InventorySave();

        for (int i = 0; i < inventorySize.y; i++)
        {
            for (int j = 0; j < inventorySize.x; j++)
            {
                if (inventorySlots[j, i].assignedItem == null) continue;

                ItemSave item = new ItemSave();
                item.posX = j;
                item.posY = i;
                item.itemId = inventorySlots[j, i].assignedItem.ItemSO.id;

                saves.items.Add(item);

                for (int k = 0; k < inventorySlots[j, i].assignedItem.assignedSlotList.Count; k++)
                {
                    if (inventorySlots[j, i] == inventorySlots[j, i].assignedItem.assignedSlotList[k]) continue;
                    inventorySlots[j, i].assignedItem.assignedSlotList[k].assignedItem = null;
                }
                Destroy(inventorySlots[j, i].assignedItem.gameObject);
                inventorySlots[j, i].assignedItem = null;
            }
        }

        //이거 나중에 prettyPrint false로 ㄲ
        EasyToJson.ToJson(saves, "MyInventory", true);

        Load();
    }

    public void Load()
    {
        InventorySave saves = EasyToJson.FromJson<InventorySave>("MyInventory");

        for (int i = 0; i < saves.items.Count; i++)
        {
            for (int j = 0; j < itemSet.Count; j++)
            {
                if (itemSet[j].id == saves.items[i].itemId)
                {
                    ItemSO itemSO = itemSet[j];
                    Item itemPf = Instantiate(itemSO.itemPf, itemParent).GetComponent<Item>();
                    itemPf.Init(itemSO);

                    inventorySlots[saves.items[i].posX, saves.items[i].posY].SetItem(itemPf, true);
                }
            }

        }
    }
}

public class InventorySave
{
    public List<ItemSave> items = new List<ItemSave>();
}

[System.Serializable]
public struct ItemSave
{
    public int posX, posY;
    public int itemId;
}
