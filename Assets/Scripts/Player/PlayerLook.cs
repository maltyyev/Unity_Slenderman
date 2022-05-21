using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField, Tooltip("Чувствительность движения камеры"), Min(1f)] private float _sensitivity;
    [SerializeField] private Transform _camera;

    #region rotation variables

    private Vector2 _lookVector;
    private float _xAxis, _yAxis;
    private float _xRotation;

    #endregion

    private void Start()
    {
        _inputManager.Controls.Player.Look.performed += OnLook;
        _inputManager.Controls.Player.Look.canceled += OnLook;
    }

    private void OnDestroy()
    {
        _inputManager.Controls.Player.Look.performed -= OnLook;
        _inputManager.Controls.Player.Look.canceled -= OnLook;
    }

    private void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _lookVector = obj.ReadValue<Vector2>();

        _xAxis = _lookVector.x;
        _yAxis = _lookVector.y;

        _xRotation -= _yAxis;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * _xAxis);
    }

    private void LateUpdate()
    {
        
    }
}
