using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allLoot;
    [SerializeField] private GameObject _leftSpawnerPoint, _rightSpawnPoint;
    private float _leftSpawnerX, _rightSpawnerX, _spawnerY;
    [SerializeField] private float _timer = 3f;
    private float _rememberTimer = 0;
    private bool _isGameOver = true;
    private float _timerDeacrease = 0.1f, _timeBeforeSpawnRateIncrease = 10f, _timerMinimum = 0.2f;
    private void Awake()
    {
        _leftSpawnerX = _leftSpawnerPoint.transform.position.x;
        _spawnerY = _leftSpawnerPoint.transform.position.y;
        _rightSpawnerX = _rightSpawnPoint.transform.position.x;
    }
    private void OnEnable()
    {
        PointsManager.onLose += GameOver;
        MenuButtons.OnGameStart += GameStart;
    }
    private void OnDisable()
    {
        PointsManager.onLose -= GameOver;
        MenuButtons.OnGameStart -= GameStart;
    }
    private IEnumerator IncreaseSpawnRate()
    {
        yield return new WaitForSeconds(_timeBeforeSpawnRateIncrease);
        if (_rememberTimer > _timerMinimum)
            _rememberTimer -= _timerDeacrease;
        yield return IncreaseSpawnRate();
    }
    private void GameStart()
    {
        StartCoroutine(IncreaseSpawnRate());
        _rememberTimer = 3f;
        _isGameOver = false;
    }
    private void GameOver()
    {
        StopAllCoroutines();
        _isGameOver = true;
    }
    private void Update()
    {
        if (_isGameOver)
            return;
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

        Vector3 SpawnPosition = new Vector3(Random.Range(_leftSpawnerX, _rightSpawnerX), _spawnerY,0);
        int SpawnLoot = Random.Range(0, _allLoot.Length);
        PoolManager.SpawnObject(_allLoot[SpawnLoot], SpawnPosition, Quaternion.identity);

    }
}
