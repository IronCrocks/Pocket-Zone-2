using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public Camera worldCamera;
    public Tilemap tilemap;
    public int enemyCount;
    public List<GameObject> enemyPrefabList;

    private BoundsInt _tilemapBounds;

    private void Awake()
    {
        _tilemapBounds = tilemap.cellBounds;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemy = SpawnEnemy();
            SetEnemyTarget(enemy);
        }
    }

    private GameObject SpawnEnemy()
    {
        var position = GetSpawnPosition();
        int enemyPrefabIndex = Random.Range(0, enemyPrefabList.Count);
        var enemy = Instantiate(enemyPrefabList[enemyPrefabIndex], position, Quaternion.identity);

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
        enemyController.player = player.transform;
        var weapon = enemy.GetComponent<Weapon>();
        weapon.target = player;
        var canvas = enemy.GetComponentInChildren<Canvas>();
        canvas.worldCamera = worldCamera;
    }
}
