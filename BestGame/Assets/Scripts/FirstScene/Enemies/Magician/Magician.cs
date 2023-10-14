using System.Collections;
using UnityEngine;

public class Magician : MonoBehaviour, IEnemy
{
    [SerializeField] private float _deathTime = 0.6f;
    [SerializeField] private GameObject _damageEffect;

    private Animator _animatorController;
    private int _hp = 5;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _hp -= damage;
            CreationDamageEffect();
        }

        if (_hp <= 0)
        {
            MagicianDeath();
        }
    }

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
