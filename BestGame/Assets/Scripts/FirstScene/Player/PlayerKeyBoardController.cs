using UnityEngine;

public class PlayerKeyBoardController : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Only for test
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _playerMovement.OnRightBtnDown();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerMovement.OnLeftBtnDown();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _playerMovement.OnBtnUp();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _playerMovement.OnBtnUp();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMovement.OnJumpBtnClick();
        }
    }
}
