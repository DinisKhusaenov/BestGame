using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Enemy))]
public class MagicianView : MonoBehaviour
{
    private const string DeathAnimation = "MagicianDeath";

    [SerializeField] private GameObject _damageEffect;

    private Animator _animator;
    private Enemy _enemy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemy.Died += MagicianDeath;
        _enemy.Damaged += CreationDamageEffect;
    }

    private void OnDisable()
    {
        _enemy.Died -= MagicianDeath;
        _enemy.Damaged -= CreationDamageEffect;
    }

    private void MagicianDeath(float deathTime)
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        _animator.SetTrigger(DeathAnimation);
        StartCoroutine(MagicianDestroy(deathTime));
    }

    private IEnumerator MagicianDestroy(float deathTime)
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }

    private void CreationDamageEffect()
    {
        var newDamage = Instantiate(_damageEffect);
        newDamage.transform.position = transform.position;

        Destroy(newDamage, 1f);
    }

    private void Attack()
    {
        _animator.SetTrigger("MagicianAttack");
    }
}
