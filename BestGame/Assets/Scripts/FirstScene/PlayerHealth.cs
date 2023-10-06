using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _hp = 3;

    public void GetDamage(int damage)
    {
        if (damage > 0)
            _hp -= damage;

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
