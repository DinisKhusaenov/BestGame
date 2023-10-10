using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpHeight = 3f;

    public static MoveState moveState = MoveState.Idle;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private float _jumpForce;
    private int _moveDirection = 0;
    private bool _isMoveBtnPressed = false;
    private Transform _playerPosition;

    public static Action OnJumped;
    public static Action OnWalked;
    public static Action OnIdled;

    public bool IsMoveBtnPressed => _isMoveBtnPressed;
    public Transform PlayerPosition => _playerPosition;

    public void OnJumpBtnClick()
    {
        if (moveState != MoveState.Jump)
        {
            Jump();
            OnJumped?.Invoke();
            moveState = MoveState.Jump;
        }
    }

    public void OnLeftBtnDown()
    {
        _moveDirection = -1;
        _spriteRenderer.flipX = true;
        _isMoveBtnPressed = true;

        SetOnWalkState();
    }

    public void OnRightBtnDown()
    {
        _moveDirection = 1;
        _spriteRenderer.flipX = false;
        _isMoveBtnPressed = true;

        SetOnWalkState();
    }

    public void OnBtnUp()
    {
        _moveDirection = 0;
        _isMoveBtnPressed = false;

        if (moveState != MoveState.Jump && PlayerCombat.attackState != AttackState.Active)
        {
            moveState = MoveState.Idle;
            OnIdled?.Invoke();
        }
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerPosition = transform;

    }

    private void Start()
    {
        _jumpForce = Mathf.Sqrt(_jumpHeight * -2 * (Physics2D.gravity.y * _rigidbody2D.gravityScale));
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(_moveDirection * _moveSpeed * Time.deltaTime, 0, 0);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void SetOnWalkState()
    {
        if (moveState != MoveState.Jump && PlayerCombat.attackState != AttackState.Active)
        {
            moveState = MoveState.Walk;
            OnWalked?.Invoke();
        }
    }
}

public enum MoveState
{
    Idle,
    Walk,
    Jump
}
