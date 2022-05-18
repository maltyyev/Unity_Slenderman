using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Controls _controls;

    public Controls Controls
    {
        get
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Enable();
            }
            return _controls;
        }
    }

    public Vector2 GetLookInput() => Controls.Player.Look.ReadValue<Vector2>();
    public Vector2 GetMovementInput() => Controls.Player.Movement.ReadValue<Vector2>();
}
