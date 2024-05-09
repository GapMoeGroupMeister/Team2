using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Inventory owner;
    public Item assignedItem = null;

    [SerializeField] private Color selectedColor;
    [SerializeField] private Color denyColor;
    private RectTransform rect;
    private Color originColor;
    private Image visual;

    public Vector2Int Position { get; private set; }
    public bool IsSelected { get; private set; }

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        visual = transform.Find("Image").GetComponent<Image>();
        originColor = visual.color;
    }

    public void SetOwner(Inventory inventory, Vector2Int position)
    {
        owner = inventory;
        this.Position = position;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="isSelect">아이템이 선택됬나</param>
    /// <param name="setItem">아이템을 세팅할 것이가</param>
    public void Select(bool isSelect, bool setItem = false)
    {
        if (InventoryManager.Instance.curSelectingItem == null) return;

        Item curItem = InventoryManager.Instance.curSelectingItem;
        Vector2Int selectedSell = curItem.SelectedSell;

        int x = Mathf.Clamp(Position.x - selectedSell.x, 0,
            owner.inventorySize.x - curItem.itemSize.x);
        int y = Mathf.Clamp(Position.y - selectedSell.y, 0,
            owner.inventorySize.y - curItem.itemSize.y);

        bool canPlace = owner.inventorySlots[x, y].SelectByItemSize(curItem.itemSize.x, curItem.itemSize.y, isSelect, setItem);

        //if (canPlace == false)
        //    return;

        if (setItem && canPlace)
        {
            owner.inventorySlots[x, y].SetItem(curItem, canPlace);
        }
    }

    public bool SelectByItemSize(int x, int y, bool isSelect, bool flag = false)
    {
        bool canPlace = true;
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (owner.inventorySlots[Position.x + j, Position.y + i].assignedItem != null)
                {
                    canPlace = false;
                }
            }
        }
        InventoryManager.Instance.curSelectingItem.canPlace = canPlace;

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                owner.inventorySlots[Position.x + j, Position.y + i]
                    .VisuallySelect(isSelect, canPlace);

                if (isSelect == false && flag == true)
                {
                    owner.inventorySlots[Position.x + j, Position.y + i]
                        .assignedItem = null;
                }
            }
        }

        return canPlace;
    }

    public void VisuallySelect(bool isSelect, bool canPlace)
    {
        visual.color = isSelect ? canPlace ? selectedColor : denyColor : originColor;
        IsSelected = isSelect;
    }

    public void SetItem(Item item, bool canPlace)
    {
        int sizeX = item.itemSize.x;
        int sizeY = item.itemSize.y;

        for (int i = 0; i < owner.inventorySlots.GetLength(1); i++)
        {
            for (int j = 0; j < owner.inventorySlots.GetLength(0); j++)
            {
                Slot curSlot = owner.inventorySlots[j, i];
                if (curSlot.IsSelected == true)
                {
                    curSlot.VisuallySelect(false, canPlace);
                }
            }
        }

        item.assignedSlotList.Clear();
        for (int i = 0; i < sizeY; i++)
        {
            for (int j = 0; j < sizeX; j++)
            {
                Slot curSlot = owner.inventorySlots[Position.x + j, Position.y + i];

                curSlot.assignedItem = item;
                curSlot.VisuallySelect(false, canPlace);
                item.assignedSlotList.Add(curSlot);
            }
        }

        Vector2 itemPos = rect.localPosition;

        if (sizeX % 2 == 0)
        {
            itemPos.x += item.SellSize.x / 2;
            itemPos.x += item.SellSize.x * (sizeX - 2);
        }
        else
        {
            itemPos.x += item.SellSize.x * (sizeX - 1) / 2;
        }

        if (sizeY % 2 == 0)
        {
            itemPos.y += item.SellSize.y / 2;
            itemPos.y += item.SellSize.y * (sizeY - 2);
        }
        else
        {
            itemPos.y += item.SellSize.y * (sizeY - 1) / 2;
        }

        Debug.Log(rect.localPosition);
        Debug.Log(itemPos);
        item.SetPosition(itemPos);
    }


    #region PointerEventRegion

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryManager.Instance.curSelectingSlot = this;
        Select(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.curSelectingSlot = null;
        Select(false);
    }

    #endregion
}
