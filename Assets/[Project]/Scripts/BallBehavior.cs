using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private float _speed;
    private Transform _start;
    private Transform _target;
    private float _time;
    private Vector2 _lerpRbTarget;

    private bool _hasBeenGrab = false;
    private Rigidbody2D _rb;

    public void Initialize(float speed, Transform startTransform, Transform targetTransform)
    {
        _speed = speed;
        _start = startTransform;
        _target = targetTransform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!_hasBeenGrab)
        {
            _time += Time.deltaTime * _speed;
            _lerpRbTarget = Vector2.Lerp(_start.position, _target.position, _time);
            if (_time >= 1)
                Destroy(gameObject);
        }


    }
}
