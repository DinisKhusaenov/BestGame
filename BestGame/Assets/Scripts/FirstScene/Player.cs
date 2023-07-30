using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private GroundCheck _groundCheck;

    private Rigidbody2D _rigidbody2D;
    private float _jumpForce;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _jumpForce = Mathf.Sqrt(_jumpHeight * -2 * (Physics2D.gravity.y * _rigidbody2D.gravityScale));
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(-1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_groundCheck.IsGround)
                Jump();
        }
    }

    private void Move(int direction)
    {
        transform.position += new Vector3(direction * _moveSpeed * Time.deltaTime, 0, 0);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
