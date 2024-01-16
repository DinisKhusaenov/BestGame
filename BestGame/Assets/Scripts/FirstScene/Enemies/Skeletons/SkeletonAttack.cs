using System.Collections;
using UnityEngine;

public abstract class SkeletonAttack : EnemyMovement
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _playerLayer;

    private int _attackDamage;
    private float _attackSpeed;
    private EnemyAttackState _attackState;

    private void Awake()
    {
        _attackState = EnemyAttackState.Passive;
    }

    private void Update()
    {
        EnemyAttack();
    }

    private void EnemyAttack()
    {
        if (GetDistanceTo(TargetPosition) <= Config.AttackDistance)
        {
            if (_attackState == EnemyAttackState.Passive)
                StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _attackState = EnemyAttackState.Active;
        yield return new WaitForSeconds(_attackSpeed / 2);

        Collider2D player = Physics2D.OverlapCircle(_attackPoint.position, Config.AttackRange, _playerLayer);

        player?.GetComponent<Player>().TakeDamage(_attackDamage);

        yield return new WaitForSeconds(_attackSpeed / 2);

        _attackState = EnemyAttackState.Passive;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, Config.AttackRange);
    }
}
