using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _hp = 3;

    public event Action OnDamaged;
    public event Action OnHeartRevivaled;

    public int HP => _hp;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _hp -= damage;
            OnDamaged?.Invoke();
            Debug.Log("-hp");
        }

        if (_hp <= 0)
        {
            Dead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Heart" && _hp < 3)
        {
            HeartRevival();
            Destroy(collision.gameObject);
        }
    }

    private void HeartRevival()
    {
        _hp++;
        OnHeartRevivaled?.Invoke();
    }

    private void Dead()
    {
        Debug.Log("Dead");
    }
}
