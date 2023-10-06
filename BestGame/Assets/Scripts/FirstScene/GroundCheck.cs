using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    public Action OnLanded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (!_player.IsMoveBtnPressed)
            {
                PlayerMovement.moveState = MoveState.Idle;
                PlayerMovement.OnIdled?.Invoke();
            }
            else
            {
                PlayerMovement.moveState = MoveState.Walk;
                PlayerMovement.OnWalked?.Invoke();
            }

            OnLanded?.Invoke();
        }
    }
}
