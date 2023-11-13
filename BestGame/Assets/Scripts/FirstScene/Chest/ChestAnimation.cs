using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Chest))]
public class ChestAnimation : MonoBehaviour
{
    private Animator _animation;
    private Chest _chest;

    private void Awake()
    {
        _animation = GetComponent<Animator>();
        _chest = GetComponent<Chest>();
    }

    private void OnEnable()
    {
        _chest.OnChestOpened += OpenChestAnimation;
    }

    private void OnDisable()
    {
        _chest.OnChestOpened -= OpenChestAnimation;
    }

    private void OpenChestAnimation()
    {
        _animation.SetTrigger("OpenChest");
    }
}
