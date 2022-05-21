using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField, Min(1f)] private float _movementSpeed;
    [SerializeField] private Transform _camera;

    #region Movement variables

    private Vector2 _movementInputVector;
    private Vector3 _movementDirection, _projectedCameraDirection;
    private Quaternion _movementRotation;
    private float _xAxis, _yAxis;

    #endregion

    private void Start()
    {
        _inputManager.Controls.Player.Movement.performed += OnMove;
        _inputManager.Controls.Player.Movement.canceled += OnMove;
    }

    private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _movementInputVector = obj.ReadValue<Vector2>();

        _xAxis = _movementInputVector.x;
        _yAxis = _movementInputVector.y;
    }

    private void FixedUpdate()
    {
        _movementDirection = Vector3.forward * _yAxis + Vector3.right * _xAxis;

        _projectedCameraDirection = Vector3.ProjectOnPlane(_camera.forward, Vector3.up);
        _movementRotation = Quaternion.LookRotation(_projectedCameraDirection);

        _movementDirection = (_movementRotation * _movementDirection).normalized;

        transform.position += _movementDirection * Time.fixedDeltaTime * _movementSpeed;
    }
}
