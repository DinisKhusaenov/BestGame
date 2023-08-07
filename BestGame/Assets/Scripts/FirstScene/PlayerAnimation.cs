using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _jumpEffect;
    [SerializeField] private GameObject _walkEffect;

    private Animator _animatorController;

    private void Start()
    {
        _animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        SetOnMoveAnimation();
        SetOnIdleAnimation();

        ActivateWalkingEffect();
    }

    private void SetOnMoveAnimation()
    {
        if (Player.moveState == MoveState.Walk)
        {
            _animatorController.Play("Walk");
        }
    }

    private void SetOnIdleAnimation()
    {
        if (Player.moveState == MoveState.Idle && Player.attackState == AttackState.Passive)
        {
            _animatorController.Play("Idle");
        }

    }

    private void OnEnable()
    {
        GetComponent<Player>().OnJumped += JumpAnimation;
        GetComponentInChildren<GroundCheck>().OnLanded += InstantiateJumpEffect;
        GetComponent<PlayerCombat>().OnAttacked += AttackAnimation;
    }

    private void OnDisable()
    {
        GetComponent<Player>().OnJumped -= JumpAnimation;
        GetComponentInChildren<GroundCheck>().OnLanded -= InstantiateJumpEffect;
        GetComponent<PlayerCombat>().OnAttacked -= AttackAnimation;
    }

    private void JumpAnimation()
    {
        _animatorController.Play("Jump");
        InstantiateJumpEffect();
    }

    private void AttackAnimation()
    {
        _animatorController.Play("Attack");
        Player.attackState = AttackState.Active;
        StartCoroutine(DisableAttack());
    }

    private IEnumerator DisableAttack()
    {
        AnimationClip[] clips = _animatorController.runtimeAnimatorController.animationClips;
        float attackLength = 0;

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "PlayerAttack")
                attackLength = clip.length;
        }

        yield return new WaitForSeconds(attackLength);
        Player.attackState = AttackState.Passive;
    }

    private void InstantiateJumpEffect()
    {
        var newEffect = Instantiate(_jumpEffect);
        newEffect.transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, 0);

        Destroy(newEffect.gameObject, 3f);
    }

    private void ActivateWalkingEffect()
    {
        if (Player.moveState == MoveState.Walk)
        {
            _walkEffect.SetActive(true);
        }
        else
        {
            _walkEffect.SetActive(false);
        }
    }
}
