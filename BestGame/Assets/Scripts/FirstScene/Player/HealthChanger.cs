using UnityEngine;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private Heart _heartOne, _heartTwo, _heartThree;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth.OnDamaged += HealthChange;
    }

    private void OnDisable()
    {
        _playerHealth.OnDamaged -= HealthChange;
    }

    private void HealthChange()
    {
        switch (_playerHealth.HP)
        {
            case 2:
                _heartThree.ChangeHealthIcon();
                break;
            case 1:
                _heartTwo.ChangeHealthIcon();
                break;
            case 0:
                _heartOne.ChangeHealthIcon();
                break;
        }
    }
}
