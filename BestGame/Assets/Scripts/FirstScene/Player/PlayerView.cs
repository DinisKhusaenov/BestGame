using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerView : MonoBehaviour
{
    private const string IsIdling = "IsIdling";
    private const string IsRunning = "IsRunning";
    private const string IsGrounded = "IsGrounded";
    private const string IsJumping = "IsJumping";
    private const string IsFalling = "IsFalling";
    private const string IsAirborne = "IsAirborn";
    private const string IsAction = "IsAction";
    private const string IsAttack = "IsAttack";
    private const string IsSwordAttack = "IsSwordAttack";

    [SerializeField] private ParticleSystem _jumpEffect;
    [SerializeField] private ParticleSystem _walkEffect;
    [SerializeField] private ParticleSystem _damageEffect;
    [SerializeField] private Color _normalColor, _damageColor;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartRunning() => _animator.SetBool(IsRunning, true);
    public void StopRunning() => _animator.SetBool(IsRunning, false);

    public void StartGrounded() => _animator.SetBool(IsGrounded, true);
    public void StopGrounded() => _animator.SetBool(IsGrounded, false);

    public void StartJumping() => _animator.SetBool(IsJumping, true);
    public void StopJumping() => _animator.SetBool(IsJumping, false);

    public void StartFalling() => _animator.SetBool(IsFalling, true);
    public void StopFalling() => _animator.SetBool(IsFalling, false);

    public void StartAirborne() => _animator.SetBool(IsAirborne, true);
    public void StopAirborne() => _animator.SetBool(IsAirborne, false);

    public void StartAction() => _animator.SetBool(IsAction, true);
    public void StopAction() => _animator.SetBool(IsAction, false);

    public void StartAttack() => _animator.SetBool(IsAttack, true);
    public void StopAttack() => _animator.SetBool(IsAttack, false);

    public void StartSwordAttack() => _animator.SetBool(IsSwordAttack, true);
    public void StopSwordAttack() => _animator.SetBool(IsSwordAttack, false);

    private void GetDamage()
    {
        CreationDamageEffect();
        StartCoroutine(Flickering());
    }

    private void CreationDamageEffect()
    {
        var newDamage = Instantiate(_damageEffect);
        newDamage.transform.position = transform.position;

        Destroy(newDamage, 1f);
    }

    private IEnumerator Flickering()
    {
        _spriteRenderer.color = _damageColor;
        yield return new WaitForSeconds(0.5f);
        _spriteRenderer.color = _normalColor;
    }

    private void CreationJumpEffect()
    {
        var newEffect = Instantiate(_jumpEffect);
        newEffect.transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, 0);

        Destroy(newEffect.gameObject, 3f);
    }
}
