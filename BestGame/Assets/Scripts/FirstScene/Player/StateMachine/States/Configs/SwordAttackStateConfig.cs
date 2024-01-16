using System;
using UnityEngine;

[Serializable]
public class SwordAttackStateConfig
{
    [SerializeField, Range(1, 10)] private int _damage;
    [SerializeField, Range(0, 10)] private float _attackRange;
    [SerializeField, Range(0, 5)] private float _attackSpeed;
    [SerializeField] private LayerMask _enemyLayer;

    public int Damage => _damage;
    public float AttackRange => _attackRange;
    public float AttackSpeed => _attackSpeed;
    public LayerMask EnemyLayer => _enemyLayer;
}
