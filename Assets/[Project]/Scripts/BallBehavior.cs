using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private float _speed;
    private Transform _start;
    private Transform _target;
    private float _time;

    private bool _hasBeenGrab = false;
    private Rigidbody2D _rb;
    private float _shakeFactor = 0;

    public void Initialize(float speed, Transform startTransform, Transform targetTransform, ScriptableColor ballType)
    {
        _speed = speed;
        _start = startTransform;
        _target = targetTransform;
        transform.position = startTransform.position;
        _rb = GetComponent<Rigidbody2D>();
        GetComponent<ColorDescriptor>().SetColor(ballType);
    }

    private void Update()
    {
        if (!_hasBeenGrab)
        {
            LerpMovement();
        }
    }

    private void LerpMovement()
    {
        _time += Time.deltaTime * _speed;
        Vector2 pos = Vector2.Lerp(_start.position, _target.position, _time);
        transform.position = pos + new Vector2(0, Mathf.Sin(Time.time * 50) * 0.1f * _shakeFactor);
        if (_time >= 1)
        {
            // print("Destroy ball : " + name);
            Destroy(gameObject);
        }
    }

    public void GrabBall(float grabTime, float grabForce, Transform graber)
    {
        if (_hasBeenGrab)
        {
            Vector2 graberDirection = (graber.position - transform.position).normalized;
            _rb.AddForce(graberDirection * grabForce, ForceMode2D.Force);
        }

        if (_shakeFactor >= 1)
        {
            _hasBeenGrab = true;
            return;
        }
        _shakeFactor += grabTime;
    }
}
