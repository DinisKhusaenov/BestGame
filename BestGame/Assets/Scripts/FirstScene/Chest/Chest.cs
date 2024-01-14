using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public event Action OnChestOpened;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Health player))
        {
            OnChestOpened?.Invoke();
        }
    }
}
