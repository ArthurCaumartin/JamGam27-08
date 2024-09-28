using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private float _speed;
    private Transform _start;
    private Transform _target;
    private float _lerpTime;

    private bool _hasBeenGrab = false;
    private Rigidbody2D _rb;
    private float _shakeFactor = 0;
    private ColorDescriptor _colorDescriptor;

    public void Initialize(float speed, Transform startTransform, Transform targetTransform, ScriptableColor color)
    {
        _speed = speed;
        _start = startTransform;
        _target = targetTransform;
        transform.position = startTransform.position;

        _rb = GetComponent<Rigidbody2D>();
        _colorDescriptor = GetComponent<ColorDescriptor>();
        _colorDescriptor.SetColor(color);
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
        _lerpTime += Time.deltaTime * _speed;
        Vector2 pos = Vector2.Lerp(_start.position, _target.position, _lerpTime);
        transform.position = pos + new Vector2(0, Mathf.Sin(Time.time * 50) * 0.1f * _shakeFactor);
        if (_lerpTime >= 1)
        {
            // print("Destroy ball : " + name);
            Destroy(gameObject);
        }
    }

    public void GrabBall(float grabTime, float grabForce, Transform graber)
    {
        if (_colorDescriptor.ScriptableColor.type == ColorType.Evile) return;
        if (_hasBeenGrab)
        {
            Vector2 graberDirection = (graber.position - transform.position).normalized;
            _rb.AddForce(graberDirection * grabForce, ForceMode2D.Force);
            return;
        }

        if (_shakeFactor >= 1)
        {
            Vector2 graberDirection = (graber.position - transform.position).normalized;
            _rb.AddForce(graberDirection * grabForce, ForceMode2D.Impulse);
            _hasBeenGrab = true;
            return;
        }
        _shakeFactor += grabTime;
    }
}
