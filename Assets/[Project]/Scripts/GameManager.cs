using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private CanvasManager _canvas;
    [SerializeField] private int _scoreToAdd;
    [SerializeField] private int _currentScore;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(_canvas)
        {
            _canvas.SetScoreText(Random.Range(5, 10000), true);
            _canvas.SetScoreText(_currentScore);
        }
    }

    public void AddScore(bool isGood)
    {
        int toAdd = isGood ? _scoreToAdd : -_scoreToAdd;
        print("To Add : " + toAdd);
        _currentScore += (int)(toAdd * Random.Range(0.9f, 1.1f));
        _canvas.SetScoreText(_currentScore);
    }
}
