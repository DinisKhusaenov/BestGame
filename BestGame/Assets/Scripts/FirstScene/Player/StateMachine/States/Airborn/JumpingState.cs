public class JumpingState : AirbornState
{
    private readonly JumpingStateConfig _jumpingStateConfig;

    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _jumpingStateConfig = player.Config.AirbornStateConfig.JumpingStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.YVelocity = _jumpingStateConfig.StartyVelocity;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Data.YVelocity < 0)
            StateSwitcher.SwitchState<FallingState>();
    }
}
