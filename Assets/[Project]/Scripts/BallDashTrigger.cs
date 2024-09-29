using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDashTrigger : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ColorDescriptor color = other.GetComponent<ColorDescriptor>();
        if (color && color.ScriptableColor.type == ColorType.Evile)
        {
            BallBehavior b = other.GetComponent<BallBehavior>();
            if(b._isDashing) return;
            b.DashOnPlayer(_playerTransform);
        }
    }
}
