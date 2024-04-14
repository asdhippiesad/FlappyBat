using System.Collections;
using UnityEngine;

public class EnemyGenerator : ObjectPool<Enemy>
{
    [SerializeField] private float _minSpawnPosition;
    [SerializeField] private float _maxSpawnPosition;

    private Coroutine _coroutine;

    private float _delay = 5f;

    private void Start() => _coroutine = StartCoroutine(GenerateEnemies());

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_minSpawnPosition, _maxSpawnPosition);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemyPool = GetObject();

        enemyPool.gameObject.SetActive(true);
        enemyPool.transform.position = spawnPoint;
    }
}
