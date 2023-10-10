using System.Collections;
using UnityEngine;

public class FlyingEye : MonoBehaviour, IEnemy
{
    [SerializeField] private float _deathTime = 2f;

    private Animator _animatorController;
    private int _hp = 2;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _hp -= damage;
        }

        if (_hp <= 0)
        {
            EyeDeath();
        }
    }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    private void EyeDeath()
    {
        GetComponent<FlyingEyeMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        _animatorController.SetTrigger("EyeDeath");
        StartCoroutine(EyeDestroy());

    }

    private IEnumerator EyeDestroy()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }
}
