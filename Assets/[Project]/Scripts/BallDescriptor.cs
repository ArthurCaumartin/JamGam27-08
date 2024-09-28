using UnityEngine;

public class BallDescriptor : MonoBehaviour
{
    private ScriptableBall _scriptableBall;

    public void SetBall(ScriptableBall value)
    {
        _scriptableBall = value;
        GetComponentInChildren<SpriteRenderer>().color = _scriptableBall.color;
    }
}
