using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    [SerializeField] private Color Debug_Color;
    [SerializeField] private float _grabForce = 5f;
    [SerializeField] private float _grabSpeed = 0.5f;
    [SerializeField] private float _grabSize = 0.5f;
    [SerializeField] private float _grabDistance = 0.5f;
    [SerializeField] private LayerMask _ballLayer;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
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
        }
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
