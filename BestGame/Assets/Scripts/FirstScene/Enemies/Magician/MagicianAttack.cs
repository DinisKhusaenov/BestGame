using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class MagicianAttack : Enemy
{
    private const int RightDirection = 1;
    private const int LeftDirection = -1;

    private AttackState _attackState = AttackState.Passive;
    private int _direction;

    private ITarget _target;
    private FireballSpawner _spawner;
    private SpriteRenderer _spriteRenderer;

    [Inject]
    private void Construct(ITarget target, FireballSpawner spawner)
    {
        _target = target;
        _spawner = spawner;

        _direction = RightDirection;
    }

    public Vector3 TargetPosition => _target.GetPosition().position;

    public void EnemyAttack()
    {
        if (GetDistanceTo(TargetPosition) <= Config.AttackDistance)
        {
            if (_attackState == AttackState.Passive)
                StartCoroutine(Attack());

            Flip();
        }
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        EnemyAttack();
    }

    private float GetDistanceTo(Vector3 to)
    {
        return Vector3.Distance(transform.position, to);
    }

    private void Flip()
    {
        if (TargetPosition.x < transform.position.x)
        {
            _spriteRenderer.flipX = true;
            _direction = LeftDirection;
        }
        else
        {
            _spriteRenderer.flipX = false;
            _direction = RightDirection;
        }
    }

    private IEnumerator Attack()
    {
        _attackState = AttackState.Active;

        yield return new WaitForSeconds(0.5f);
        FireballCreation();

        yield return new WaitForSeconds(Config.AttackSpeed - 0.5f);
        _attackState = AttackState.Passive;
    }

    private void FireballCreation()
    {
        
    }
}
