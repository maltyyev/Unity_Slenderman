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

    private void LateUpdate()
    {
        _lookVector = _inputManager.GetLookInput();

        _xAxis = _lookVector.x * Time.deltaTime * _sensitivity;
        _yAxis = _lookVector.y * Time.deltaTime * _sensitivity;

        _xRotation -= _yAxis;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * _xAxis);
    }
}
