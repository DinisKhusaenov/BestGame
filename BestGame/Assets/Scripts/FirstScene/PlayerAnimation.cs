using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _jumpEffect;
    [SerializeField] private GameObject _walkEffect;

    private Animator _animatorController;

    private void OnEnable()
    {
        PlayerMovement.OnJumped += SetOnJumpAnimation;
        PlayerMovement.OnWalked += SetOnMoveAnimation;
        PlayerMovement.OnIdled += SetOnIdleAnimation;

        GetComponentInChildren<GroundCheck>().OnLanded += InstantiateJumpEffect;
        GetComponent<PlayerCombat>().OnAttacked += SetOnAttackAnimation;
        GetComponent<PlayerCombat>().OnAttackEnded += AttackEnd;
    }

    private void OnDisable()
    {
        PlayerMovement.OnJumped -= SetOnJumpAnimation;
        PlayerMovement.OnWalked -= SetOnMoveAnimation;
        PlayerMovement.OnIdled -= SetOnIdleAnimation;

        GetComponentInChildren<GroundCheck>().OnLanded -= InstantiateJumpEffect;
        GetComponent<PlayerCombat>().OnAttacked -= SetOnAttackAnimation;
        GetComponent<PlayerCombat>().OnAttackEnded -= AttackEnd;
    }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
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

        InstantiateJumpEffect();
    }

    private void SetOnAttackAnimation()
    {
        _animatorController.Play("Attack");
        PlayerCombat.attackState = AttackState.Active;
    }

    private void InstantiateJumpEffect()
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
