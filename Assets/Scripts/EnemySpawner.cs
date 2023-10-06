using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private ItemSpawner _itemSpawner;
    [SerializeField]
    private Camera _worldCamera;
    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private int _enemyCount;
    [SerializeField]
    private List<GameObject> _enemyPrefabList;

    private BoundsInt _tilemapBounds;

    private void Awake()
    {
        _tilemapBounds = _tilemap.cellBounds;
    }

    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            var enemy = SpawnEnemy();
            SetEnemyTarget(enemy);
        }
    }

    private GameObject SpawnEnemy()
    {
        var position = GetSpawnPosition();
        int enemyPrefabIndex = Random.Range(0, _enemyPrefabList.Count);
        var enemy = Instantiate(_enemyPrefabList[enemyPrefabIndex], position, Quaternion.identity);

        return enemy;
    }

    private Vector3 GetSpawnPosition()
    {
        return new Vector3
        {
            x = Random.Range(_tilemapBounds.xMin + 1, _tilemapBounds.xMax),
            y = Random.Range(_tilemapBounds.yMin + 1, _tilemapBounds.yMax)
        };
    }

    private void SetEnemyTarget(GameObject enemy)
    {
        var enemyController = enemy.GetComponent<EnemyController>();
        var weapon = enemy.GetComponent<Weapon>();
        var canvas = enemy.GetComponentInChildren<Canvas>();
        var lootable = enemy.GetComponent<LootableObject>();

        enemyController.player = _player.transform;
        weapon.target = _player;
        canvas.worldCamera = _worldCamera;
        lootable.ItemSpawner = _itemSpawner;
    }
}
