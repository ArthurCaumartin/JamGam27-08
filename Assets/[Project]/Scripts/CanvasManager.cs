using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private List<Image> _hearts;
    private int _targetScore;
    private float _scoreToPrint;
    public void SetScoreText(int currentScore, bool skipAnim = false)
    {
        _targetScore = currentScore;
        if (skipAnim) _scoreToPrint = _targetScore;
    }

    public void SetHeart(int life)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            _hearts[i].enabled = false;
        }
        for (int i = 0; i < life; i++)
        {
            _hearts[i].enabled = true;
        }
    }

    private void Update()
    {
        _scoreToPrint = Mathf.Lerp(_scoreToPrint, _targetScore, Time.deltaTime * 10f);
        _scoreText.text = ((int)_scoreToPrint).ToString();
    }
}
