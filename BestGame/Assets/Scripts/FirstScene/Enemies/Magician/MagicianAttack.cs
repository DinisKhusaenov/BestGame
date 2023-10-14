using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MagicianAttack : MonoBehaviour, IAttack
{
    [SerializeField] private float _attackDistance = 15f;
    [SerializeField] private Fireball _fireballPrefab;

    private int _attackDamage = 1;
    private float _attackSpeed = 3f;
    private AttackState _attackState = AttackState.Passive;
    private int _direction;
    private readonly float _fireballSpawnDistance = 0.7f;

    private Transform _target;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public void EnemyAttack()
    {
        if (GetDistanceToTarget(_target) <= _attackDistance)
        {
            if (_attackState == AttackState.Passive)
                StartCoroutine(Attack());

            Flip();
        }
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _target = PlayerMovement.Instance.PlayerPosition;
    }

    private void Update()
    {
        EnemyAttack();
    }

    private float GetDistanceToTarget(Transform to)
    {
        return Vector2.Distance(transform.position, to.position);
    }

    private void Flip()
    {
        if (_target.position.x < transform.position.x)
        {
            _spriteRenderer.flipX = true;
            _direction = -1;
        }
        else
        {
            _spriteRenderer.flipX = false;
            _direction = 1;
        }
    }

    private IEnumerator Attack()
    {
        _attackState = AttackState.Active;
        _animator.SetTrigger("MagicianAttack");

        yield return new WaitForSeconds(0.5f);
        FireballCreation();

        yield return new WaitForSeconds(_attackSpeed - 0.5f);
        _attackState = AttackState.Passive;
    }

    private void FireballCreation()
    {
        var newFireball = Instantiate(_fireballPrefab);
        newFireball.Direction = _direction;
        newFireball.AttackDamage = _attackDamage;

        if (_direction == 1)
            newFireball.transform.position = new Vector3(transform.position.x + _fireballSpawnDistance, transform.position.y, 0);
        else
            newFireball.transform.position = new Vector3(transform.position.x - _fireballSpawnDistance, transform.position.y, 0);

        StartCoroutine(FireballDestruction(newFireball));
    }

    private IEnumerator FireballDestruction(Fireball fireball)
    {
        yield return new WaitForSeconds(3f);

        if (fireball != null)
            StartCoroutine(fireball.FireballDestroy());
    }
}
