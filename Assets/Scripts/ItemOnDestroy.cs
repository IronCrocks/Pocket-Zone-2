using System.Collections.Generic;
using UnityEngine;

public class ItemOnDestroy : MonoBehaviour
{
    public List<GameObject> itemPrefabList;

    private void OnDestroy()
    {
        var itemPrefabIndex = Random.Range(0, itemPrefabList.Count);

        Instantiate(itemPrefabList[itemPrefabIndex], transform.position, Quaternion.identity);
    }
}
