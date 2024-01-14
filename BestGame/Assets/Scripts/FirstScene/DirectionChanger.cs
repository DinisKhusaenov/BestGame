using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IChangeDirection>(out IChangeDirection changeDirection))
            changeDirection.ChangeDirection();
    }
}
