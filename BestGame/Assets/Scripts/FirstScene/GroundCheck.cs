using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool _isGround = false;

    public bool IsGround => _isGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            _isGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            _isGround = false;
    }
}
