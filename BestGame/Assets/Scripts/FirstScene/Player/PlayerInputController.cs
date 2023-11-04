using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public event Action OnLeftBtnPressed;
    public event Action OnRightBtnPressed;
    public event Action OnBtnUp;
    public event Action OnJumpBtnClicked;
    public event Action OnAttackBtnClicked;

    public void OnLeftBtnPress()
    {
        OnLeftBtnPressed?.Invoke();
    }

    public void OnRightBtnPress()
    {
        OnRightBtnPressed?.Invoke();
    }

    public void OnBtnReleased()
    {
        OnBtnUp?.Invoke();
    }

    public void OnJumpBtnClick()
    {
        OnJumpBtnClicked?.Invoke();
    }

    public void OnAttackBtnClick()
    {
        OnAttackBtnClicked?.Invoke();
    }

    //Only for test
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnRightBtnPress();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnLeftBtnPress();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            OnBtnReleased();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            OnBtnReleased();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpBtnClick();
        }
    }
}
