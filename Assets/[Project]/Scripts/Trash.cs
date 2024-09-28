using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private ColorDescriptor _color;
    private void OnTriggerEnter2D(Collider2D other)
    {
        BallBehavior ball = other.GetComponent<BallBehavior>();
        if (!ball) return;
        ColorDescriptor c = other.GetComponent<ColorDescriptor>();
        if (c.IsSameColor(_color.ScriptableColor))
            Destroy(ball.gameObject);
    }
}
