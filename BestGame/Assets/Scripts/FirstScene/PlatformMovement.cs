using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _direction = 1;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DirectionChanger directionChanger))
        {
            _direction *= -1;
        }
    }
}
