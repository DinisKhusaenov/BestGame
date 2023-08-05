using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Action OnLanded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Player.moveState = MoveState.Idle;
            OnLanded?.Invoke();
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            Player.moveState = MoveState.Jump;
    }
}
