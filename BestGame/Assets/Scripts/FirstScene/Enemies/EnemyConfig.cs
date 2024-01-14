using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _attack;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _deathTime;

    public Enemy Prefab => _prefab;
    public int MaxHealth => _maxHealth;
    public int Attack => _attack;
    public float Speed => _speed;
    public float AttackDistance => _attackDistance;
    public float DeathTime => _deathTime;
}
