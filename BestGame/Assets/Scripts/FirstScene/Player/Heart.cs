using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Heart : MonoBehaviour
{
    private Animator _animatorController;

    public void ChangeHealthIcon()
    {
        _animatorController.SetTrigger("HeartDistruction");
    }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }
}
