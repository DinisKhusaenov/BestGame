using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private AirbornStateConfig _airbornStateConfig;
    [SerializeField] private RunningStateConfig _runningStateConfig;

    public AirbornStateConfig AirbornStateConfig => _airbornStateConfig;

    public RunningStateConfig RunningStateConfig => _runningStateConfig;
}
