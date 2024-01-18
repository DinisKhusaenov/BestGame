using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Enemy))]
public class LargeSkeletonView : MonoBehaviour
{
    private const string DeathAnimation = "SkeletonTwoDeath";
    private const float DamageEffectTime = 1;

    [SerializeField] private ParticleSystem _damageEffect;

    private Enemy _enemy;
    private Animator _animatorController;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += SkeletonDeath;
        _enemy.Damaged += CreationDamageEffect;
    }

    private void OnDisable()
    {
        _enemy.Died -= SkeletonDeath;
        _enemy.Damaged -= CreationDamageEffect;
    }

    private void SkeletonDeath(float deathTime)
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        _animatorController.SetTrigger(DeathAnimation);
        StartCoroutine(SkeletonDestroy(deathTime));
    }

    private IEnumerator SkeletonDestroy(float deathTime)
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }

    private void CreationDamageEffect()
    {
        var damage = Instantiate(_damageEffect);
        damage.transform.position = transform.position;

        Destroy(damage, DamageEffectTime);
    }
}
