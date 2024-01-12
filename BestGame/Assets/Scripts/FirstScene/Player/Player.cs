using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerStateMachine _stateMachine;
    private GroundChecker _groundChecker;
    private PlayerConfig _config;
    private CharacterController _characterController;

    public PlayerInput Input => _playerInput;
    public GroundChecker GroundChecker => _groundChecker;
    public PlayerConfig Config => _config;
    public CharacterController Controller => _characterController;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _stateMachine = new PlayerStateMachine(this);
        _characterController = GetComponent<CharacterController>();
    }

    [Inject]
    public void Construct(GroundChecker groundChecker, PlayerConfig config)
    {
        _groundChecker = groundChecker;
        _config = config;
    }

    private void Update()
    {
        _stateMachine.Update();

        _stateMachine.HandleInput();
    }
}
