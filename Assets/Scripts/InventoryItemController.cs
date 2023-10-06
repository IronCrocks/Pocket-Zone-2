using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item Item;

    public void Remove()
    {
        Managers.InventoryManager.Remove(Item);
        Destroy(gameObject);
    }
}
