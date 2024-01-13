using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private ITarget _target;
    private Vector3 _targetPositionWithCamera;

    [Inject]
    private void Construct(ITarget target)
    {
        _target = target;
    }

    public Vector3 TargetPosition => _target.GetPosition().position;

    private void Start()
    {
        _targetPositionWithCamera = new Vector3(TargetPosition.x, TargetPosition.y + 1.2f, transform.position.z);
        transform.position = _targetPositionWithCamera;
    }

    private void Update()
    {
        _targetPositionWithCamera = new Vector3(TargetPosition.x, TargetPosition.y + 1.2f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, _targetPositionWithCamera, _moveSpeed * Time.deltaTime);
    }
}
