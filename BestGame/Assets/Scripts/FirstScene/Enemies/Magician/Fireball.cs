using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fireball : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed = 5f;

    private int _attackDamage = 1;
    private int _direction;
    private float _destroyTime = 0.6f;

    private Animator _animator;

    public int AttackDamage
    {
        get { return _attackDamage; }
        set { if (value > 0) _attackDamage = value; }
    }

    public int Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public IEnumerator FireballDestroy()
    {
        _animator?.SetTrigger("FireballEnd");
        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }

    public void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerAttack(player);
        }
    }

    private void PlayerAttack(Player player)
    {
        player.TakeDamage(_attackDamage);
        StartCoroutine(FireballDestroy());
        _speed = 0;
    }
}
