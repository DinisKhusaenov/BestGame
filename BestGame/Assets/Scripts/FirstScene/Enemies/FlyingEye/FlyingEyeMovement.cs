using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlyingEyeMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _direction = 1;
    private SpriteRenderer _spriteRenderer;

    public void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DirectionChanger directionChanger))
        {
            ChangeDirection();
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
}
