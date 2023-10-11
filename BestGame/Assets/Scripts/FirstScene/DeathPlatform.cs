using System.Collections;
using UnityEngine;

public class DeathPlatform : MonoBehaviour
{
    [SerializeField] private float _timeBetweenDamage = 2f;

    private int _damage = 1;
    private static bool _isActive = true;
    private static bool _isGone = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth) && _isActive)
        {
            StartCoroutine(PlayerDamage(playerHealth));
            _isActive = false;
            _isGone = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            _isGone = true;
        }
    }

    private IEnumerator PlayerDamage(PlayerHealth playerHealth)
    {
        playerHealth.TakeDamage(_damage);

        yield return new WaitForSeconds(_timeBetweenDamage);
        _isActive = true;

        if (!_isGone)
        {
            playerHealth.TakeDamage(_damage);
            yield return new WaitForSeconds(_timeBetweenDamage);

            if (!_isGone)
                playerHealth.TakeDamage(_damage);
        }
    }
}
