using System.Collections;
using UnityEngine;

public class DeathPlatform : MonoBehaviour
{
    [SerializeField] private float _timeBetweenDamage = 2f;

    private int _damage = 1;
    private static bool _isActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth) && _isActive)
        {
            StartCoroutine(PlayerDamage(playerHealth));
            _isActive = false;
            Debug.Log("-hp");
        }
    }

    private IEnumerator PlayerDamage(PlayerHealth playerHealth)
    {
        playerHealth.TakeDamage(_damage);

        yield return new WaitForSeconds(_timeBetweenDamage);
        _isActive = true;
    }
}
