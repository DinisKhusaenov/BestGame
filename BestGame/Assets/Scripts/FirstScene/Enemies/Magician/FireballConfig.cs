using UnityEngine;

[CreateAssetMenu(fileName = "FireballConfig", menuName = "Configs/FireballConfig")]
public class FireballConfig : ScriptableObject
{
    [SerializeField] private Fireball _prefab;
    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField, Range(0, 3)] private int _damage;
    [SerializeField, Range(0, 5)] private float _destroyTime;

    public float Speed => _speed;
    public int Damage => _damage;
    public float DestroyTime => _destroyTime;
    public Fireball Prefab => _prefab;
}
