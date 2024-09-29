using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _targetScore;
    private float _scoreToPrint;
    public void SetScoreText(int currentScore, bool skipAnim = false)
    {
        _targetScore = currentScore;
        if (skipAnim) _scoreToPrint = _targetScore;
    }

    private void Update()
    {
        _scoreToPrint = Mathf.Lerp(_scoreToPrint, _targetScore, Time.deltaTime * 10f);
        _scoreText.text = ((int)_scoreToPrint).ToString();
    }
}
