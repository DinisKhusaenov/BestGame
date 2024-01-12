using System;
using UnityEngine.InputSystem;

public abstract class GroundedState : MovementState
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
            StateSwitcher.StateSwitch<FallingState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Jump.started += OnJumpButtonPressed;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        Input.Movement.Jump.started -= OnJumpButtonPressed;
    }

    private void OnJumpButtonPressed(InputAction.CallbackContext obj) => StateSwitcher.StateSwitch<JumpingState>();
}
