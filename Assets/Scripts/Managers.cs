using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(DataManager))]
public class Managers : MonoBehaviour
{
    public static Managers Instance { get; private set; }
    public static InventoryManager InventoryManager { get; private set; }
    public static PlayerManager PlayerManager { get; private set; }
    public static DataManager DataManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InventoryManager = GetComponent<InventoryManager>();
        PlayerManager = GetComponent<PlayerManager>();
        DataManager = GetComponent<DataManager>();
    }
}
