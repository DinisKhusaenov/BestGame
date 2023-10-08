using System.Collections;
using UnityEngine;

public class Skeleton : MonoBehaviour, IEnemy
{
    [SerializeField] private float _deathTime = 2f;
    private Animator _animatorController;

    private int _hp = 5;

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

        _animatorController.SetTrigger("SkeletonDeath");
        StartCoroutine(SkeletonDestroy());

    }

    private IEnumerator SkeletonDestroy()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }
}
