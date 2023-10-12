using UnityEngine;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private Heart _heartOne, _heartTwo, _heartThree;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth.OnDamaged += HealthDestruction;
        _playerHealth.OnHeartRevivaled += HealthRevival;
    }

    private void OnDisable()
    {
        _playerHealth.OnDamaged -= HealthDestruction;
        _playerHealth.OnHeartRevivaled -= HealthRevival;
    }

    private void HealthDestruction()
    {
        switch (_playerHealth.HP)
        {
            case 2:
                _heartThree.HeartDistructionAnimation();
                break;
            case 1:
                _heartTwo.HeartDistructionAnimation();
                if (_heartThree.IsActive)
                {
                    _heartThree.HeartDistructionAnimation();
                }
                break;
            case 0:
                _heartOne.HeartDistructionAnimation(); 
                if (_heartThree.IsActive)
                {
                    _heartThree.HeartDistructionAnimation();
                }
                if (_heartTwo.IsActive)
                {
                    _heartThree.HeartDistructionAnimation();
                }
                break;
        }
    }

    private void HealthRevival()
    {
        switch (_playerHealth.HP)
        {
            case 3:
                _heartThree.HeartRevivalAnimation();
                break;
            case 2:
                _heartTwo.HeartRevivalAnimation();
                break;
        }
    }
}
