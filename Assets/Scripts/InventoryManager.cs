using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItemPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        var inventoryItem = Items.FirstOrDefault(p => p.id == item.id);

        if (inventoryItem == null)
        {
            AddNewItem(item);
        }
        else
        {
            //IncreaseCount(item);
        }
    }

    private void AddNewItem(Item item)
    {
        Items.Add(item);

        ShowItems();
    }

    private void IncreaseCount(Item item)
    {
        foreach (Transform transform in ItemContent)
        {
            var inventoryItem = transform.gameObject.GetComponent<InventoryItemController>();
            if (inventoryItem.Item.id == item.id)
            {
                var itemCount = inventoryItem.transform.Find("ItemCount").GetComponent<TMP_Text>();

                if (int.TryParse(itemCount.text, out int result))
                {
                    result++;
                    itemCount.text = result.ToString();
                }
                break;
            }
        }
        //var inventoryItems = ItemContent.gameObject.GetComponentsInChildren<ItemController>();
        //var t = inventoryItems[0];
        //int y = t.Item.id;
        //var inventoryItem = inventoryItems.FirstOrDefault(p => p.Item.id == item.id);
        //var itemCount = inventoryItem.transform.Find("ItemCount").GetComponent<TMP_Text>();

        //if (int.TryParse(itemCount.text, out int result))
        //{
        //    itemCount.text = result++.ToString();
        //}
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ShowItems()
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

            itemIcon.sprite = item.icon;
            inventoryItemController.Item = item;
        }
    }
}
