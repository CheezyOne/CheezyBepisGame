using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using DG.Tweening;

public class BarrierBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public GameObject objectToMove;
    [SerializeField] private float _timer = 10f;
    private float _rememberTimer = 0;

    static public float barrierDuration = 1f;
    private bool _isGameOver = true;

    public void Awake()
    {
        _rememberTimer = _timer;
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
    private void GameStart()
    {
        _isGameOver = false;
    }
    private void GameOver()
    {
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
            SpawnNewBarrier();
        }
    }

    private void SpawnNewBarrier()
    {
        float posX, posY;
        int isRightSide = Random.Range(0, 2);
        if (isRightSide == 1)
        {
            posX = Random.Range(15f, 11f);
            posY = Random.Range(-5f, 5f);
            PoolManager.SpawnObject(prefab, new Vector3(posX, posY, 0), Quaternion.Euler(0, 0, 180));
        }
        else{
            posX = Random.Range(-15f, -11f);
            posY = Random.Range(-5f, 5f);
            PoolManager.SpawnObject(prefab, new Vector3(posX, posY, 0), Quaternion.Euler(0, 0, 0));
        }

        
        

    }


    


}
