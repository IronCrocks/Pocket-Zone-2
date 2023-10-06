using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IDataHandler
{
    [SerializeField]
    private Transform ItemContent;
    [SerializeField]
    private GameObject InventoryItemPrefab;

    private ItemHolder _itemHolder;
    private Dictionary<int, int> Items = new();

    private void Awake()
    {
        _itemHolder = GetComponent<ItemHolder>();
    }

    public void Add(Item item)
    {

        if (Items.ContainsKey(item.id))
        {
            Items[item.id]++;
        }
        else
        {
            Items.Add(item.id, 1);
        }

        UpdateInventory();

    }

    public object GetData() => Items;

    public void LoadData(object data)
    {
        if (data is Dictionary<int, int> items)
        {
            Items = items;
            UpdateInventory();
        }
    }

    public void Remove(Item item)
    {
        Items.Remove(item.id);
    }

    public void UpdateInventory()
    {
        foreach (Transform transform in ItemContent)
        {
            Destroy(transform.gameObject);
        }

        foreach (var item in Items)
        {
            var inventoryItem = Instantiate(InventoryItemPrefab, ItemContent);
            var itemIcon = inventoryItem.transform.Find("ItemIcon").GetComponent<Image>();
            var inventoryItemController = inventoryItem.GetComponent<InventoryItemController>();
            var itemCount = inventoryItem.transform.Find("ItemCount").GetComponent<TMP_Text>();

            var scriptableItem = _itemHolder.GetItemById(item.Key);

            itemIcon.sprite = scriptableItem.icon;
            inventoryItemController.Item = scriptableItem;
            itemCount.text = item.Value.ToString();

            bool isActive = item.Value != 1;
            itemCount.gameObject.SetActive(isActive);
        }
    }
}
