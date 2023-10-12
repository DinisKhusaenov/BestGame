using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Heart : MonoBehaviour
{
    private Animator _animatorController;

    private bool _isActive = true;

    public bool IsActive => _isActive;

    public void HeartDistructionAnimation()
    {
        _animatorController.SetTrigger("HeartDistruction");
        _isActive = false;
    }

    public void HeartRevivalAnimation()
    {
        _animatorController.SetTrigger("HeartRevival");
        _isActive = true;
    }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }
}
