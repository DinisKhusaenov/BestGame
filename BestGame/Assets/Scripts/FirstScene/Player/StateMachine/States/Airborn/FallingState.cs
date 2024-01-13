public class FallingState : AirbornState
{
    private readonly GroundChecker _groundChecker;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _groundChecker = player.GroundChecker;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
        {
            Data.YVelocity = 0;

            if (IsHorizontalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
            else
                StateSwitcher.SwitchState<RunningState>();
        }
    }
}
