using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public event Action<float> Died;
    public event Action Damaged;

    protected EnemyConfig Config { get; private set; }
    protected float Speed;

    private int _health;

    public void Initialize(EnemyConfig enemyConfig)
    {
        Config = enemyConfig;

        Speed = Config.Speed;
        _health = enemyConfig.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _health -= damage;
        Damaged?.Invoke();

        if (_health < 0)
        {
            _health = 0;
            Died?.Invoke(Config.DeathTime);
            Speed = 0;
        }
    }
}
