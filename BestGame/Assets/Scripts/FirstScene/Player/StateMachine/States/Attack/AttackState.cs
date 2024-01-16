public abstract class AttackState : ActionState
{
    public AttackState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartAttack();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopAttack();
    }

    public override void Update()
    {
        base.Update();
    }
}
