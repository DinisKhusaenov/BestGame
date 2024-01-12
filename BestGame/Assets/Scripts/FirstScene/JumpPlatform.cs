using System.Collections;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private bool _isJumping = false;
    private GameObject _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isJumping = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isJumping = false;
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
