using UnityEngine;

public class EnemyMovement : Enemy
{
    [SerializeField] private float _speed;

    private int _direction = 1;
    private float _moveDistance = 5f;
    private Transform _target;

    private SpriteRenderer _spriteRenderer;

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    public float GetDistanceToTarget(Transform to)
    {
        return Vector2.Distance(transform.position, to.position);
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if (GetDistanceToTarget(_target) <= _moveDistance)
        {
            if (_target.position.x < transform.position.x)
            {
                _direction = -1;
                Flip();
            }
            else
            {
                _direction = 1;
                Flip();
            }
        }
    }

    private void ChangeDirection()
    {
        _direction *= -1;
        Flip();
    }

    private void Flip()
    {
        if (_direction == -1)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DirectionChanger directionChanger))
        {
            ChangeDirection();
        }
    }
}
