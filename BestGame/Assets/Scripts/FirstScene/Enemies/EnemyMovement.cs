using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class EnemyMovement : Enemy, IChangeDirection
{
    private const float MoveDistance = 5f;
    private const int RightDirection = 1;
    private const int LeftDirection = -1;

    private int _direction;
    private ITarget _target;
    private SpriteRenderer _spriteRenderer;

    [Inject]
    private void Construct(ITarget target)
    {
        _target = target;

        _direction = RightDirection;
    }

    public Vector3 TargetPosition => _target.GetPosition().position;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        MoveToPlayer();
    }

    public void ChangeDirection()
    {
        _direction *= LeftDirection;
        Flip();
    }

    protected float GetDistanceTo(Vector3 to)
    {
        return Vector3.Distance(transform.position, to);
    }

    private void Move()
    {
        transform.Translate(_direction * Speed * Time.deltaTime, 0, 0);
    }

    private void MoveToPlayer()
    {
        if (GetDistanceTo(TargetPosition) <= MoveDistance)
        {
            if (TargetPosition.x < transform.position.x)
            {
                _direction = LeftDirection;
                Flip();
            }
            else
            {
                _direction = RightDirection;
                Flip();
            }
        }
    }

    private void Flip()
    {
        if (_direction == LeftDirection)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
