public class RunningState : GroundedState
{
    private RunningStateConfig _runningStateConfig;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _runningStateConfig = player.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _runningStateConfig.Speed;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }
}
