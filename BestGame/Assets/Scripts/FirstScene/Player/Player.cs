using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour, ITarget
{
    [SerializeField] private GroundChecker _groundChecker;

    private PlayerInput _playerInput;
    private PlayerStateMachine _stateMachine;
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

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    [Inject]
    public void Construct(PlayerConfig config)
    {
        _config = config;
    }

    private void Update()
    {
        _stateMachine.Update();

        _stateMachine.HandleInput();
    }

    public Transform GetPosition()
    {
        return transform;
    }
}
