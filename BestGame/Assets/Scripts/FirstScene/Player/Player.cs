using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour, ITarget, IDamageable
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private PlayerView _playerView;

    private PlayerInput _playerInput;
    private PlayerStateMachine _stateMachine;
    private PlayerConfig _config;
    private CharacterController _characterController;

    private IHealthStat _health;    

    public PlayerInput Input => _playerInput;
    public GroundChecker GroundChecker => _groundChecker;
    public PlayerConfig Config => _config;
    public CharacterController Controller => _characterController;
    public Transform AttackPoint => _attackPoint;
    public PlayerView View => _playerView;

    private void Awake()
    {
        _playerView.Initialize();
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

    public void TakeDamage(int damage) => _health.Reduce(damage);

    public void Heal(int value) => _health.Add(value);
}
