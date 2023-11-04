using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _enemyLayer;

    public static AttackState attackState = AttackState.Passive;

    private int _attackDamage = 3;
    private float _attackSpeed = 1f;

    private PlayerInputController _playerInput;

    public Action OnAttacked;
    public Action OnAttackEnded;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputController>();
    }

    private void OnEnable()
    {
        _playerInput.OnAttackBtnClicked += PlayerAttack;
    }

    private void OnDisable()
    {
        _playerInput.OnAttackBtnClicked -= PlayerAttack;
    }


    private void PlayerAttack()
    {
        if (attackState == AttackState.Passive)
            Attack();
    }

    private void Attack()
    {
        OnAttacked?.Invoke();
        attackState = AttackState.Active;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy?.GetComponent<IEnemy>()?.TakeDamage(_attackDamage);
        }

        StartCoroutine(DisableAttack());
    }

    private IEnumerator DisableAttack()
    {
        yield return new WaitForSeconds(_attackSpeed);
        attackState = AttackState.Passive;
        OnAttackEnded?.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}

public enum AttackState
{
    Active,
    Passive
}
