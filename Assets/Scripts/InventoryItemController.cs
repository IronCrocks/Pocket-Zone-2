using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item Item;

    public void Remove()
    {
        InventoryManager.Instance.Remove(Item);
        Destroy(gameObject);
    }
}
