using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action OnCoinsChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health player))
        {
            CoinHolder.Instance.AddCoin(1);
            OnCoinsChanged?.Invoke();
            Destroy(gameObject);
        }
    }
}
