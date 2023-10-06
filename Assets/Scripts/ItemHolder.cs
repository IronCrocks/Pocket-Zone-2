using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private List<Item> Items;

    public Item GetItemById(int id) => Items.FirstOrDefault(p => p.id == id);
}
