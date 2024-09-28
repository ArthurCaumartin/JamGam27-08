using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [Space]
    [SerializeField] private Transform _ballTarget;
    [SerializeField] private float _ballSpeed = 5;
    [SerializeField] private float _spawnRate = 1.5f;
    [SerializeField] private List<ScriptableColor> _goodColorList;
    [SerializeField] private List<ScriptableColor> _badColorList;
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _spawnRate)
        {
            _time = 0;
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(_ballPrefab, transform.position, Quaternion.identity, transform);
        BallBehavior ball = newBall.GetComponent<BallBehavior>();
        ScriptableColor s_color = Random.value > .5f ? _goodColorList[Random.Range(0, _goodColorList.Count)] : _badColorList[Random.Range(0, _badColorList.Count)];
        ball.Initialize(_ballSpeed, transform, _ballTarget, s_color);
    }
}


