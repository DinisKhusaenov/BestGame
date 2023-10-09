using System.Collections;
using UnityEngine;

public class SkeletonWithSledgehammer : MonoBehaviour, IEnemy
{
    [SerializeField] private float _deathTime = 2f;

    private int _hp = 5;
    private Animator _animatorController;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _hp -= damage;
        }

        if (_hp <= 0)
        {
            SkeletonDeath();
        }
    }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    private void SkeletonDeath()
    {
        GetComponent<SkeletonAttack>().enabled = false;
        GetComponent<SkeletonMovement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        _animatorController.SetTrigger("SkeletonTwoDeath");
        StartCoroutine(SkeletonDestroy());
    }

    private IEnumerator SkeletonDestroy()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }
}
