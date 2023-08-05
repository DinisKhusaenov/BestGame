using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpHeight = 3f;

    public static MoveState moveState = MoveState.Idle;

    private Rigidbody2D _rigidbody2D;

    private float _jumpForce;
    private static int _hp = 3;
    private int _moveDirection = 0;
    private bool _isMoveBtnPressed = false;

    public Action OnJumped;
    
    public void GetDamage()
    {
        if (_hp > 0)
            _hp--;
    }

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
        GetComponent<SpriteRenderer>().flipX = true;
        _isMoveBtnPressed = true;

        if (moveState != MoveState.Jump)
            moveState = MoveState.Walk;
    }

    public void OnRightBtnDown()
    {
        _moveDirection = 1;
        GetComponent<SpriteRenderer>().flipX = false;
        _isMoveBtnPressed = true;

        if (moveState != MoveState.Jump)
            moveState = MoveState.Walk;
    }

    public void OnBtnUp()
    {
        _moveDirection = 0;
        _isMoveBtnPressed = false;

        if (moveState != MoveState.Jump)
            moveState = MoveState.Idle;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _jumpForce = Mathf.Sqrt(_jumpHeight * -2 * (Physics2D.gravity.y * _rigidbody2D.gravityScale));
    }


    private void Update()
    {
        Move();
        SetOnMoveState();
    }

    private void SetOnMoveState()
    {
        if (moveState != MoveState.Jump && _isMoveBtnPressed)
        {
            moveState = MoveState.Walk;
        }
    }

    private void Move()
    {
        transform.position += new Vector3(_moveDirection * _moveSpeed * Time.deltaTime, 0, 0);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}

public enum MoveState
{
    Idle,
    Walk,
    Jump
}
