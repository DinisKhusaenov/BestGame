using UnityEngine;

public class Fireball : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed = 5f;

    private int _attackDamage;
    private int _direction;

    public int AttackDamage
    {
        get { return _attackDamage; }
        set { if (value > 0) _attackDamage = value; }
    }

    public int Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    private void Start()
    {
        if (_direction == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    private void Update()
    {
        Move();
    }
}
