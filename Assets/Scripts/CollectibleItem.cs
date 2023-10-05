using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public Item item;

    public void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        Pickup();
    }
}
