using System.Collections;
using UnityEngine;

public class Magician : Enemy
{
    [SerializeField] private float _deathTime = 0.6f;
    [SerializeField] private GameObject _damageEffect;

    private Animator _animatorController;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    private void MagicianDeath()
    {
        GetComponent<MagicianAttack>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        _animatorController.SetTrigger("MagicianDeath");
        StartCoroutine(MagicianDestroy());
    }

    private IEnumerator MagicianDestroy()
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
