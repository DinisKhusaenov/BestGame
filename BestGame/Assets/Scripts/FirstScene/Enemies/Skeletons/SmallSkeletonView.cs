using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Enemy))]
public class SmallSkeletonView : MonoBehaviour
{
    private const string DeathAnimation = "SkeletonDeath";
    private const float DamageEffectTime = 1;

    [SerializeField] private ParticleSystem _damageEffect;

    private Animator _animatorController;
    private Enemy _enemy;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
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
