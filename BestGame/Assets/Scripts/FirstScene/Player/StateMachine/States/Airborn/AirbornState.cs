using UnityEngine;

public abstract class AirbornState : MovementState
{
    private readonly AirbornStateConfig _config;

    protected AirbornState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _config = player.Config.AirbornStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        Data.YVelocity -= _config.BaseGravity * Time.deltaTime;
    }
}
