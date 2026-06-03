using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    private Vector3 _movementDirection;
    private Vector3 _velocityXZ;
    private float _velocityY;
    private bool _isGrounded;
    private bool _isSprint;
    private float _currentSpeed = 1f;
    public bool IsSprint => _isSprint;


    [SerializeField] private float _walkSpeed = 1f;
    [SerializeField] private float _sprintSpeed = 5f;
    [SerializeField] private float _acceleration = 1f;
    [SerializeField] private CharacterController _charactercontroller;
    [SerializeField] private float _gravityScale = 1;

    private void Awake()
    {
        _currentSpeed = _walkSpeed;
    }

    private void Start()
    {
        _charactercontroller = GetComponent<CharacterController>();
    }

    public void Move()
    {
        CalculateVelocityXZ();

        CalculateVelocityY();

        CalculateAcceleration();

        Vector3 velocity = new Vector3( _velocityXZ.x, _velocityY, _velocityXZ.z);

        _charactercontroller.Move(_velocityXZ * Time.deltaTime);
    }
    
    private void Update()
    {
        CheckIsGrounded();
        ResetVelocityY();
        Move();
    }

    public void SetMovementDirection(Vector2 inputDirection)
    {
        _movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
    }

    private void CalculateAcceleration()
    {
        if (_movementDirection.magnitude > 0.01)
        {
            if (_isSprint)
            {
                _currentSpeed = _currentSpeed + _acceleration * Time.deltaTime;
            }
            else
            {
                _currentSpeed = _currentSpeed - _acceleration * Time.deltaTime;
            }
            _currentSpeed = Mathf.Clamp(_currentSpeed, _walkSpeed, _sprintSpeed);
        }
        else
        {
            _currentSpeed = 0;
        }
    }

    private void CalculateVelocityXZ()
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 xDirection = _movementDirection.x * cameraTransform.right;
        Vector3 zDirection = _movementDirection.z * cameraTransform.forward;
        Vector3 direction = xDirection + zDirection;
        direction.y = 0;

        if (_movementDirection.magnitude > 0.01)
        {
            _velocityXZ = direction.normalized * _currentSpeed;
        }
        else
        {
            _velocityXZ = Vector3.zero;
        }
    }

    private void CalculateVelocityY()
    {
        _velocityY = _velocityY + Physics.gravity.y * _gravityScale * Time.deltaTime; 
    }

    private void CheckIsGrounded()
    {
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        _isGrounded = Physics.CheckSphere(transform.position, 0.5f, groundLayer);
    }

    private void ResetVelocityY()
    {
        if (_isGrounded == true && _velocityY < 0)
        {
            _velocityY = -2f;
        }
    }

    public void SetSprint(bool isSprint)
    {
        _isSprint = isSprint;
    }

}
