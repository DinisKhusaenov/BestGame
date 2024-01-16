using UnityEngine.InputSystem;

public abstract class GroundedState : ActionState
{
    private readonly GroundChecker _groundChecker;

    protected GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
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

        if (_groundChecker.IsTouches == false)
            StateSwitcher.SwitchState<FallingState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Action.Jump.started += OnJumpButtonPressed;
        Input.Action.Attack.started += OnSwordAttackButtonPressed;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        Input.Action.Jump.started -= OnJumpButtonPressed;
        Input.Action.Attack.started -= OnSwordAttackButtonPressed;
    }

    private void OnJumpButtonPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpingState>();
    private void OnSwordAttackButtonPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<SwordAttackState>();
}
