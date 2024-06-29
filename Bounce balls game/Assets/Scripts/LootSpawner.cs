using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allLoot;
    [SerializeField] private GameObject _leftSpawnerPoint, _rightSpawnPoint;
    private float _leftSpawnerX, _rightSpawnerX, _spawnerY;
    [SerializeField] private float _timer = 1f;
    private float _rememberTimer = 0;
    private void Awake()
    {
        _rememberTimer = _timer;
        _leftSpawnerX = _leftSpawnerPoint.transform.position.x;
        _spawnerY = _leftSpawnerPoint.transform.position.y;
        _rightSpawnerX = _rightSpawnPoint.transform.position.x;
    }
    private void Update()
    {
        Timer();
    }
    private void Timer()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = _rememberTimer;
            SpawnNewLoot();
        }
    }
    private void SpawnNewLoot()
    {
        Vector3 SpawnPosition =new Vector3(Random.Range(_leftSpawnerX, _rightSpawnerX), _spawnerY,0);
        int SpawnLoot = Random.Range(0, _allLoot.Length);
        PoolManager.SpawnObject(_allLoot[SpawnLoot], SpawnPosition, Quaternion.identity);
    }
}
