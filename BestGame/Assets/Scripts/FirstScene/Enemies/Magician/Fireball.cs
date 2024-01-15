using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private const int ZeroSpeed = 0;

    public event Action<float> Destoryed;

    private float _speed;
    private int _damage ;
    private float _destroyTime;
    private int _direction;
    private float _attackTime;
    private float _timer;

    private void Start()
    {
        if (_direction == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Update()
    {
        Move();
        DestroyFireball();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable player))
        {
            player.TakeDamage(_damage);
            _speed = ZeroSpeed;
            Destoryed?.Invoke(_destroyTime);
        }
    }

    public void Initialize(float speed, int damage, float destroyTime)
    {
        _speed = speed;
        _damage = damage;
        _destroyTime = destroyTime;
    }

    public void Launch(int direction, float attackTime)
    {
        _direction = direction;
        _attackTime = attackTime;
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    private void DestroyFireball()
    {
        if (_timer >= _attackTime)
            Destoryed?.Invoke(_destroyTime);

        _timer += Time.deltaTime;
    }
}
