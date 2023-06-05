using UnityEngine;

public class MoveController:MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _backSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _angleSpeed;

    public bool IsAbleToForward = true;
    private Vector3 _velocity;


    private void Update() => Move();

    public void MoveForward() => _velocity = _forwardSpeed * Time.fixedDeltaTime * transform.forward;

    public void MoveBackward() => _velocity = -transform.forward * _backSpeed * Time.fixedDeltaTime;

    public void MoveSideways(int direction) => _velocity += Mathf.Sign(direction) * transform.right * _sideSpeed * Time.fixedDeltaTime;

    public void Turn(int direction) => transform.Rotate(100f * Mathf.Sign(direction) * Time.deltaTime * Vector3.up);

    public void Stop() => _velocity = Vector3.zero;

    private void Move() => _characterController.Move(_velocity);
}
