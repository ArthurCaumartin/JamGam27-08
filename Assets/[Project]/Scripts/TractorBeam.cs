using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TractorBeam : MonoBehaviour
{
    [SerializeField] private Color Debug_Color;
    [Space]
    [SerializeField] private Transform _snapTransform;
    [Space]
    [SerializeField] private float _grabForce = 5f;
    [SerializeField] private float _grabSpeed = 0.5f;
    [SerializeField] private float _grabSize = 0.5f;
    [SerializeField] private float _grabDistance = 0.5f;
    [SerializeField] private LayerMask _ballLayer;
    private Transform _snapBall;
    private float _snapTime;
    private LineRenderer _line;

    void Start()
    {
        _line = GetComponentInChildren<LineRenderer>();
    }

    private void FixedUpdate()
    {
        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, transform.TransformPoint(Vector2.right * _grabDistance));

        _snapTime += Time.fixedDeltaTime;
        if (_snapBall)
        {
            Rigidbody2D ballRb = _snapBall.GetComponent<Rigidbody2D>();
            ballRb.velocity = Vector2.zero;
            ballRb.MovePosition(_snapTransform.position);
            return;
        }

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _grabSize, transform.right, _grabDistance);
        // print(hits.Length);
        if (hits.Length == 0)
        {
            return;
        }

        foreach (var item in hits)
        {
            BallBehavior ball = item.collider.GetComponent<BallBehavior>();
            ball?.GrabBall(_grabSpeed * Time.fixedDeltaTime * GameManager.instance.GetGameSpeed(), _grabForce, transform);
            if (Vector2.Distance(item.transform.position, _snapTransform.position) < 1f && item.collider.gameObject.layer == 10 && _snapTime > 1)
            {
                _snapBall = item.transform;
                return;
            }
        }
    }

    public void PushSnap()
    {
        if (_snapBall)
        {
            _snapTime = 0;
            Rigidbody2D rb = _snapBall.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * 300, ForceMode2D.Impulse);
            _snapBall = null;
        }
    }

    private void OnDisable()
    {
        _snapBall = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Debug_Color;
        for (float i = 0; i < _grabDistance; i += 0.1f)
        {
            Gizmos.DrawSphere(transform.TransformPoint(Vector2.right * Mathf.InverseLerp(0, _grabDistance, i) * _grabDistance), _grabSize);
        }
    }
}
