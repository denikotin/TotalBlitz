using Assets.Scripts.Logic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _backSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _angleSpeed;
    [SerializeField] private Vector3 _direction;

    private IInputService _inputService;
    private Quaternion _rotation;
    private float _xAxis;
    private float _zAxis;

    public void Construct(IInputService inputService) => _inputService = inputService;

    private void Update()
    {
        GetAxis();
        GetRotation();
        Move();
        Rotate();
    }

    private void Move()
    {
        _direction = new Vector3(_xAxis, 0, _zAxis).normalized;
        Vector3 velocity = GenerateVelocity();
        _characterController.Move(velocity);
    }
    private void Rotate() => transform.rotation = _rotation;
    private Vector3 GenerateVelocity()
    {
        Vector3 velocity;
        if (_direction == Vector3.forward)
        {
            velocity = _rotation * _direction * _forwardSpeed * Time.fixedDeltaTime;
        }
        else if (_direction == Vector3.back)
        {
            velocity = _rotation * _direction * _backSpeed * Time.fixedDeltaTime;
        }
        else if ((_direction == Vector3.right) || (_direction == Vector3.left))
        {
            velocity = _rotation * _direction * _sideSpeed * Time.fixedDeltaTime;
        }
        else
        {
            velocity = _rotation * _direction * _backSpeed * Time.fixedDeltaTime;
        }
        return velocity;
    }
    private void GetAxis()
    {
        _xAxis =  _inputService.GetDirection().xAxis;
        _zAxis = _inputService.GetDirection().zAxis;
    }
    private void GetRotation() => _rotation = _inputService.GetRotation();

}
