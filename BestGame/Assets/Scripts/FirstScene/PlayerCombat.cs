using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _atackRange;
    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private int _attackDamage = 3;

    public Action OnAttacked;
    
    public void OnAttackBtnClick()
    {
        if (Player.attackState == AttackState.Passive)
            Attack();
    }

    private void Attack()
    {
        OnAttacked?.Invoke();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _atackRange, _enemyLayer);

        // Damage enemies
        Debug.Log("Attack");
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _atackRange);
    }
}
