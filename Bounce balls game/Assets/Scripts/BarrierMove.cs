using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class BarrierMove : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public PathType pathType = PathType.CatmullRom;
    PathMode pathMode = PathMode.TopDown2D;
    private float _rememberTimer = 0;
    [SerializeField] private float _timer = 10f;


    void OnEnable()
    {
        waypoints[0] = new Vector3(transform.position.x, transform.position.y);
        waypoints[1] = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f));

        if (transform.position.x > 0)
        {
            waypoints[2] = new Vector3(Random.Range(-25f, -20f), Random.Range(-5f, 5f));
        } else 
        {
            waypoints[2] = new Vector3(Random.Range(25f, 20f), Random.Range(-5f, 5f));
        }
        
        // Convert the list of waypoints to an array
        Vector3[] pathArray = waypoints.ToArray();
        
        // Move the object along the path
        transform.DOPath(pathArray, 10f, pathType, pathMode);
        //transform.DOPath(pathArray, 100/Loot.LootPoints, pathType, pathMode);


    }
    public void Awake()
    {
        _rememberTimer = _timer;
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
            PoolManager.ReturnObjectToPool(gameObject);
        }
    }



}
