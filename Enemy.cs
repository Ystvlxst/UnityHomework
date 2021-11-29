using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;

    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2;
    private Animator _animator;
    private Transform[] _points;

    private int _currentPoint;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2 = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _animator.SetBool(AnimatorPlayerController.Params.IsRunning, true);
    }

    private void FixedUpdate()
    {
        float scaleEnemyX = 0.31f;
        float scaleEnemyY = 0.28f;
        Transform target = _points[_currentPoint];
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            transform.localScale = new Vector2(scaleEnemyX, scaleEnemyY);

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;

                transform.localScale = new Vector2(-scaleEnemyX, scaleEnemyY);
            }
        }
    }
}
