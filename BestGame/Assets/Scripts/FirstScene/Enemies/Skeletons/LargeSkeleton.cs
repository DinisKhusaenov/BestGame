using System.Collections;
using UnityEngine;

public class LargeSkeleton : EnemyMovement
{
    [SerializeField] private float _deathTime = 2f;
    [SerializeField] private GameObject _damageEffect;

    private Animator _animatorController;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    private void SkeletonDeath()
    {
        GetComponent<SmallSkeleton>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        _animatorController.SetTrigger("SkeletonTwoDeath");
        StartCoroutine(SkeletonDestroy());
    }

    private IEnumerator SkeletonDestroy()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }

    private void CreationDamageEffect()
    {
        var newDamage = Instantiate(_damageEffect);
        newDamage.transform.position = transform.position;

        Destroy(newDamage, 1f);
    }
}
