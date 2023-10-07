using System;
using UnityEngine;

public class Skeleton : MonoBehaviour, IEnemy
{
    private int _hp = 5;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _hp -= damage;
        }

        if (_hp <= 0)
        {
            Dead();
        }

        Debug.Log("enemy hp " + _hp);
    }

    private void Dead()
    {
        Debug.Log("enemy dead");
    }
}
