using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _jumpEffect;
    [SerializeField] private GameObject _walkEffect;
    [SerializeField] private GameObject _damageEffect;
    [SerializeField] private readonly Color _normalColor, _damageColor;

    private Animator _animatorController;
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        PlayerMovement.OnJumped += SetOnJumpAnimation;
        PlayerMovement.OnWalked += SetOnMoveAnimation;
        PlayerMovement.OnIdled += SetOnIdleAnimation;

        GetComponentInChildren<GroundCheck>().OnLanded += CreationJumpEffect;
        GetComponent<PlayerCombat>().OnAttacked += SetOnAttackAnimation;
        GetComponent<PlayerCombat>().OnAttackEnded += AttackEnd;
        GetComponent<PlayerHealth>().OnDamaged += GetDamage;
    }

    private void OnDisable()
    {
        PlayerMovement.OnJumped -= SetOnJumpAnimation;
        PlayerMovement.OnWalked -= SetOnMoveAnimation;
        PlayerMovement.OnIdled -= SetOnIdleAnimation;

        GetComponentInChildren<GroundCheck>().OnLanded -= CreationJumpEffect;
        GetComponent<PlayerCombat>().OnAttacked -= SetOnAttackAnimation;
        GetComponent<PlayerCombat>().OnAttackEnded -= AttackEnd;
        GetComponent<PlayerHealth>().OnDamaged -= GetDamage;
    }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ActivateWalkingEffect();
    }

    private void SetOnMoveAnimation()
    {
        if (PlayerMovement.moveState == MoveState.Walk && PlayerCombat.attackState == AttackState.Passive)
        {
            _animatorController.Play("Walk");
        }
    }

    private void SetOnIdleAnimation()
    {
        if (PlayerMovement.moveState == MoveState.Idle && PlayerCombat.attackState == AttackState.Passive)
        {
            _animatorController.Play("Idle");
        }

    }

    private void AttackEnd()
    {
        SetOnIdleAnimation();
        SetOnMoveAnimation();
    }

    private void SetOnJumpAnimation()
    {
        if (PlayerCombat.attackState == AttackState.Passive)
            _animatorController.Play("Jump");

        CreationJumpEffect();
    }

    private void SetOnAttackAnimation()
    {
        _animatorController.SetTrigger("PlayerAttack");
        PlayerCombat.attackState = AttackState.Active;
    }

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

    private void ActivateWalkingEffect()
    {
        if (PlayerMovement.moveState == MoveState.Walk)
        {
            _walkEffect.SetActive(true);
        }
        else
        {
            _walkEffect.SetActive(false);
        }
    }
}
