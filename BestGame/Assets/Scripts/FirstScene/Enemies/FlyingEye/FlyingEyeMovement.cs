using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class FlyingEyeMovement : Enemy, IChangeDirection
{
    private const int RightDirection = 1;
    private const int LeftDirection = -1;

    private int _direction;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _direction = RightDirection;
    }

    private void Update()
    {
        Move();
    }

    public void ChangeDirection()
    {
        _direction *= LeftDirection;
        Flip();
    }

    private void Move()
    {
        transform.Translate(_direction * Speed * Time.deltaTime, 0, 0);
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
