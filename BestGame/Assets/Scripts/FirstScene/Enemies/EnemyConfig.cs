using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private Enemy _prefab;
    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField, Range(0, 10)] private int _maxHealth;
    [SerializeField, Range(0, 10)] private int _attack;
    [SerializeField, Range(0, 10)] private float _attackRange;
    [SerializeField, Range(0, 50)] private float _attackDistance;
    [SerializeField, Range(0, 10)] private float _attackSpeed;
    [SerializeField, Range(0, 10)] private float _deathTime;

    public Enemy Prefab => _prefab;
    public int MaxHealth => _maxHealth;
    public int Attack => _attack;
    public float Speed => _speed;
    public float AttackDistance => _attackDistance;
    public float DeathTime => _deathTime;
    public float AttackRange => _attackRange;
    public float AttackSpeed => _attackSpeed;
}
