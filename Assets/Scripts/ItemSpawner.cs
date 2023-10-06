using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _itemPrefabList;

    public void SpawnRandomItem(Vector2 position)
    {
        var itemPrefabIndex = Random.Range(0, _itemPrefabList.Count);

        Instantiate(_itemPrefabList[itemPrefabIndex], position, Quaternion.identity);
    }
}
