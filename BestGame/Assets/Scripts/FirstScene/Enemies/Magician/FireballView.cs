using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FireballView : MonoBehaviour
{
    [SerializeField] private Fireball _fireball;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _fireball.Destoryed += FirebalDestroy;
    }

    private void OnDisable()
    {
        _fireball.Destoryed -= FirebalDestroy;
    }

    private void FirebalDestroy(float destroyTime)
    {
        StartCoroutine(Destroy(destroyTime));
    }

    private IEnumerator Destroy(float destroyTime)
    {
        _animator?.SetTrigger("FireballEnd");
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
