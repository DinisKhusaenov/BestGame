using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Player _player;

    protected MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Player player)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _player = player;
    }

    protected PlayerInput Input => _player.Input;
    protected CharacterController PlayerController => _player.Controller;
    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    protected Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.XVelocity = Data.XInput * Data.Speed;
    }

    public virtual void Update()
    {
        Vector3 velocity = GetConvertedVelocity();

        PlayerController.Move(velocity * Time.deltaTime);
        _player.transform.rotation = GetRotationFrom(velocity);
    }

    protected virtual void AddInputActionsCallbacks() { }

    protected virtual void RemoveInputActionsCallbacks() { }

    protected bool IsHorizontalInputZero() => Data.XInput == 0;

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.x > 0)
            return TurnRight;

        if (velocity.x < 0)
            return TurnLeft;

        return _player.transform.rotation;
    }

    private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity, 0); 

    private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();
}
