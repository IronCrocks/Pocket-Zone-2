using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField]
    private Item item;

    public void Collect()
    {
        Managers.InventoryManager.Add(item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        Collect();
    }
}
