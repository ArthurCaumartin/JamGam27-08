using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [Space]
    [SerializeField] private Transform _ballTarget;
    [SerializeField] private float _spawnRate;
    private List<GameObject> _ballList = new List<GameObject>();
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        if(_time >= _spawnRate)
        {
            _time = 0;
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(_ballPrefab, transform.position, Quaternion.identity, transform);
        _ballList.Add(newBall);
    }
}
