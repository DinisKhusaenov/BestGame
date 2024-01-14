using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private AirbornStateConfig _airbornStateConfig;
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private int _maxHealth;

    public AirbornStateConfig AirbornStateConfig => _airbornStateConfig;
    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public int MaxHealth => _maxHealth;
}
