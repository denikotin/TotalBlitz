using Assets.Scripts.Logic;
using Assets.Scripts.Logic.Camera;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _backSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _angleSpeed;
    [SerializeField] private Vector3 _direction;

    public bool IsAbleToForward = true;

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
    private void Rotate()
    {
        //if (_direction.magnitude != 0)
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation( _direction), Time.fixedDeltaTime * _angleSpeed);
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, 100f* Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.Q)) 
        {
            transform.Rotate(Vector3.up, -100f * Time.deltaTime);
        }
    }

    private Vector3 GenerateVelocity()
    {
        Vector3 velocity;
        if (_direction == Vector3.forward && IsAbleToForward )
        {
            velocity =  transform.forward * _forwardSpeed * Time.fixedDeltaTime;
        }
        else if (_direction == Vector3.back)
        {
            velocity =  -transform.forward * Time.fixedDeltaTime;
        }
        else if (_direction == Vector3.right)
        {
            velocity = transform.right * Time.fixedDeltaTime;
        }
        else if (_direction == Vector3.left)
        {
            velocity = -transform.right * Time.fixedDeltaTime;
        }
        else if (!IsAbleToForward)
        {
            velocity = Vector3.zero;
        }
        else
        {
            velocity = _direction * Time.fixedDeltaTime;
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
