using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovementCharacteristics _characteristics;
    [SerializeField] private Transform _camera;
    
    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";
    private readonly string _speed = "Speed";
    private readonly string _run = "Run";

    private const float _distanceOffsetCamera = 5f;

    private float _verticalInput;
    private float _horizontalInput;
    private float _runInput;

    private Animator _animator;
    private CharacterController _characterController;
    private Vector3 _direction;
    private Quaternion _look;

    private Vector3 TargetRotate => _direction;
    private bool Idle => _horizontalInput == 0.0f && _verticalInput == 0.0f;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        Cursor.visible = _characteristics.CursorVisible;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if (_characterController.isGrounded)
        {
            _horizontalInput = Input.GetAxis(_horizontal);
            _verticalInput = Input.GetAxis(_vertical);
            _runInput = Input.GetAxis(_run);

            _direction = _camera.TransformDirection(_horizontalInput, 0, _verticalInput).normalized;
            
            PlayAnimation();
        }

        _direction.y -= _characteristics.Gravity * Time.deltaTime;
        float speed = _runInput * _characteristics.RunSpeed + _characteristics.MovementSpeed;
        Vector3 direction = _direction * speed * Time.deltaTime;

        direction.y = _direction.y;

        _characterController.Move(direction);
    }

    private void Rotate()
    {
        if(Idle)
            return;
        
        Vector3 target = TargetRotate;
        target.y = 0;
        
        _look = Quaternion.LookRotation(target);

        float speed = _characteristics.AngularSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _look, speed);
    }

    private void PlayAnimation()
    {
        float maxMovementValue = Mathf.Max(Mathf.Abs(_horizontalInput), Mathf.Abs(_verticalInput));
        float speed = _runInput * maxMovementValue + maxMovementValue;
        
        _animator.SetFloat(_speed, speed);
    }
}