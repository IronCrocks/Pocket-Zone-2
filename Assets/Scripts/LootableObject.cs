using UnityEngine;

public class LootableObject : MonoBehaviour
{
    public ItemSpawner ItemSpawner;

    private bool _isQuitting;

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!_isQuitting)
        {
            ItemSpawner.SpawnRandomItem(transform.position);
        }
    }
}
