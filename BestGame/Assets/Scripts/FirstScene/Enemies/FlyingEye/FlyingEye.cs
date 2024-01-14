using System.Collections;
using UnityEngine;

public class FlyingEye : Enemy
{
    [SerializeField] private float _deathTime = 2f;

    private Animator _animatorController;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    private void EyeDeath()
    {
        GetComponent<FlyingEyeMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        _animatorController.SetTrigger("EyeDeath");
        StartCoroutine(EyeDestroy());

    }

    private IEnumerator EyeDestroy()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }
}
