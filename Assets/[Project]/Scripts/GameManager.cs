using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private CanvasManager _canvas;
    [Space]
    [SerializeField] private int _scoreToAdd;
    [SerializeField] private int _currentScore;
    [Space]
    [SerializeField] private float _maxMultSpeed = 3f;
    [SerializeField] private float _minMultSpeed = 1f;
    [SerializeField] private int _maxScoreSpeed = 3000;
    [SerializeField] private int _minScoreSpeed = 1000;
    public float _gameSpeed = 1;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (_canvas)
        {
            _canvas.SetScoreText(Random.Range(5, 10000), true);
            _canvas.SetScoreText(_currentScore);
        }
    }

    public float GetGameSpeed()
    {
        _gameSpeed = Mathf.Lerp(_minMultSpeed, _maxMultSpeed, Mathf.InverseLerp(_minScoreSpeed, _maxScoreSpeed, _currentScore));
        return _gameSpeed;
    }

    public void AddScore(bool isGood)
    {
        int toAdd = isGood ? _scoreToAdd : -_scoreToAdd;
        print("To Add : " + toAdd);
        _currentScore += (int)(toAdd * Random.Range(0.9f, 1.1f));
        _canvas.SetScoreText(_currentScore);
    }
}
