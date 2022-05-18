using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField, Min(1f)] private float _movementSpeed;

    private CharacterController _characterController;

    #region Movement variables

    private Vector2 _movementInputVector;
    private Vector3 _movementDirection;
    private float _xAxis, _yAxis;

    #endregion

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        _movementInputVector = _inputManager.GetMovementInput();

        _xAxis = _movementInputVector.x;
        _yAxis = _movementInputVector.y;

        _movementDirection = Vector3.forward * _yAxis + Vector3.right * _xAxis;
        _characterController.Move(transform.TransformDirection(_movementDirection) * Time.fixedDeltaTime * _movementSpeed);
    }
}
