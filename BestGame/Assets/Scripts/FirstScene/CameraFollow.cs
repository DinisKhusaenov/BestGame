using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;

    private Vector3 _targetPositionWithCamera;

    private void Start()
    {
        _targetPositionWithCamera = new Vector3(_target.position.x, _target.position.y + 1.5f, transform.position.z);
        transform.position = _targetPositionWithCamera;
    }

    private void Update()
    {
        _targetPositionWithCamera = new Vector3(_target.position.x, _target.position.y + 1.5f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, _targetPositionWithCamera, _moveSpeed * Time.deltaTime);
    }
}
