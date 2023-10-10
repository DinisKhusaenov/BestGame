using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _hp = 3;

    public event Action OnDamaged;

    public int HP => _hp;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _hp -= damage;
            OnDamaged?.Invoke();
        }

        if (_hp <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Debug.Log("Dead");
    }
}
