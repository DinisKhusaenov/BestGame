using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private AirbornStateConfig _airbornStateConfig;
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField, Range(1, 10)] private int _maxHealth;
    [SerializeField] private AttackStateConfig _attackStateConfig;

    public AirbornStateConfig AirbornStateConfig => _airbornStateConfig;
    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public int MaxHealth => _maxHealth;
    public AttackStateConfig AttackStateConfig => _attackStateConfig;
}
