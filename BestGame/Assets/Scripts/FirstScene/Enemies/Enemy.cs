using System;
using UnityEngine;
using Zenject;

public abstract class Enemy : MonoBehaviour
{
    public event Action Died;

    private int _health;

    [Inject]
    public void Construct(EnemyConfig enemyConfig)
    {
        _health = enemyConfig.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _health -= damage;

        if (_health < 0)
        {
            _health = 0;
            Died?.Invoke();
        }
    }
}
