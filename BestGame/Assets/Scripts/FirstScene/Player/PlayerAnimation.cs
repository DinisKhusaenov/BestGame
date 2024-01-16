using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _jumpEffect;
    [SerializeField] private GameObject _walkEffect;
    [SerializeField] private GameObject _damageEffect;
    [SerializeField] private Color _normalColor, _damageColor;

    private Animator _animatorController;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SetOnJumpAnimation()
    {
            _animatorController.Play("Jump");

        CreationJumpEffect();
    }

    private void SetOnAttackAnimation()
    {
        _animatorController.SetTrigger("PlayerAttack");
    }

    private void GetDamage()
    {
        CreationDamageEffect();
        StartCoroutine(Flickering());
    }

    private void CreationDamageEffect()
    {
        var newDamage = Instantiate(_damageEffect);
        newDamage.transform.position = transform.position;

        Destroy(newDamage, 1f);
    }

    private IEnumerator Flickering()
    {
        _spriteRenderer.color = _damageColor;
        yield return new WaitForSeconds(0.5f);
        _spriteRenderer.color = _normalColor;
    }

    private void CreationJumpEffect()
    {
        var newEffect = Instantiate(_jumpEffect);
        newEffect.transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, 0);

        Destroy(newEffect.gameObject, 3f);
    }
}
