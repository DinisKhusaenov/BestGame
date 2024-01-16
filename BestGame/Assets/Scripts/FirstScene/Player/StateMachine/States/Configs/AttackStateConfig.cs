using System;
using UnityEngine;

[Serializable]
public class AttackStateConfig 
{
    [SerializeField] private SwordAttackStateConfig _swordAttackStateConfig;

    public SwordAttackStateConfig SwordAttackStateConfig => _swordAttackStateConfig;
}
