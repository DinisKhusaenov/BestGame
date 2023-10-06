using System;
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _atackRange;
    [SerializeField] private LayerMask _enemyLayer;

    public static AttackState attackState = AttackState.Passive;

    private int _attackDamage = 3;
    private float _attackRange = 2f;

    public Action OnAttacked;
    
    public void OnAttackBtnClick()
    {
        if (attackState == AttackState.Passive)
            Attack();
    }

    private void Attack()
    {
        OnAttacked?.Invoke();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _atackRange, _enemyLayer);

        // Damage enemies
        StartCoroutine(DisableAttack());
        Debug.Log("Attack");
    }

    private IEnumerator DisableAttack()
    {
        yield return new WaitForSeconds(_attackRange);
        attackState = AttackState.Passive;
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _atackRange);
    }
}

public enum AttackState
{
    Active,
    Passive
}
