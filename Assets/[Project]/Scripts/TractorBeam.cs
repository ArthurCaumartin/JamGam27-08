using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private void FixedUpdate()
    {
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
            ball?.GrabBall(_grabSpeed * Time.fixedDeltaTime, _grabForce, transform);
            if(Vector2.Distance(item.transform.position, _snapTransform.position) < 1f && item.collider.gameObject.layer == 10)
            {
                _snapBall = item.transform;
                return;
            }
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
