using System.Collections;
using UnityEngine;

public class SmallSkeleton : EnemyMovement
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private string _attackAnimationName = "SkeletonAttack";
    [SerializeField] private float _attackDistance = 1f;
    [SerializeField] private int _attackDamage = 1;

    private float _attackSpeed = 1.5f;

    private Animator _animatorController;
    private Transform _target;

    private AttackState _skeletonAttackState = AttackState.Passive;

    public void EnemyAttack()
    {
    }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        EnemyAttack();
    }

    private IEnumerator Attack()
    {
        _skeletonAttackState = AttackState.Active;
        yield return new WaitForSeconds(_attackSpeed/2);

        Collider2D player = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _playerLayer);

        player?.GetComponent<Player>().TakeDamage(_attackDamage);

        _animatorController.SetTrigger(_attackAnimationName);
        yield return new WaitForSeconds(_attackSpeed/2);

        _skeletonAttackState = AttackState.Passive;
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
