using System.Collections;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private bool _isJumping = false;
    private GameObject _player;

    private void OnEnable()
    {
        PlayerMovement.OnJumped += Jump;
    }

    private void OnDisable()
    {
        PlayerMovement.OnJumped -= Jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            _isJumping = true;
            _player = playerMovement.gameObject;
        }
    }

    private void Jump()
    {
        if (_isJumping)
        {
            _player.gameObject.GetComponent<Rigidbody2D>().velocity *= _jumpForce;
            _isJumping = false;
        }
    }
}
