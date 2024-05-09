using UnityEngine;

public class SpawnSystem : MonoSingleton<SpawnSystem>
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private int enemyCount;
    
    private void Start()
    {
        InvokeRepeating("EnemySpawn", 1f, 60f);
    }

    public void EnemySpawn()
    {
        enemyCount = Random.Range(7, 12);

        for (int i = 0; i <= enemyCount; i++)
        {
            int number = Random.Range(0, _enemyPrefabs.Length);
            int randomPos = Random.Range(0, _spawnPositions.Length);

            Instantiate(_enemyPrefabs[number], _spawnPositions[randomPos].position, Quaternion.identity);
        }
    }
}
