using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Heart : MonoBehaviour
{
    private Animator _animatorController;

    public void HeartDistructionAnimation()
    {
        _animatorController.SetTrigger("HeartDistruction");
    }

    public void HeartRevivalAnimation()
    {
        _animatorController.SetTrigger("HeartRevival");
    }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }
}
