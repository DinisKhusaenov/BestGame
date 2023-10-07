using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SkeletonMovement))]
public class SkeletonAttack : MonoBehaviour, IAttack
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayer;

    private int _attackDamage = 1;
    private float _attackDistance = 1f;
    private float _attackSpeed = 0.5f;

    private SkeletonMovement _skeletonMovement;
    private Animator _animatorController;
    private Transform _target;

    private AttackState _skeletonAttackState = AttackState.Passive;

    public void EnemyAttack()
    {
        if (_skeletonMovement.GetDistanceToTarget(_target) <= _attackDistance && _skeletonAttackState == AttackState.Passive)
        {
            StartCoroutine(Attack());
        }
    }

    private void Awake()
    {
        _skeletonMovement = GetComponent<SkeletonMovement>();
        _animatorController = GetComponent<Animator>();
    }

    private void Start()
    {
        _target = PlayerMovement.Instance.PlayerPosition;
    }

    private void Update()
    {
        EnemyAttack();
    }

    private IEnumerator Attack()
    {
        Collider2D player = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _playerLayer);

        player.GetComponent<PlayerHealth>()?.TakeDamage(_attackDamage);

        _skeletonAttackState = AttackState.Active;
        _animatorController.SetBool("SkeletonAttack", true);

        yield return new WaitForSeconds(_attackSpeed);
        _skeletonAttackState = AttackState.Passive;

        _animatorController.SetBool("SkeletonAttack", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
