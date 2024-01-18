using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Enemy))]
public class FlyingEyeView : MonoBehaviour
{
    private const string DeathAnimation = "EyeDeath";

    private Enemy _enemy;
    private Animator _animatorController;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += EyeDeath;
    }

    private void OnDisable()
    {
        _enemy.Died += EyeDeath;
    }

    private void EyeDeath(float deathTime)
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        _animatorController.SetTrigger(DeathAnimation);
        StartCoroutine(EyeDestroy(deathTime));
    }

    private IEnumerator EyeDestroy(float deathTime)
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}
