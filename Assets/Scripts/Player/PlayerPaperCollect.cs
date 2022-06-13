using UnityEngine;

public class PlayerPaperCollect : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private CollectiblePaperInfo _collectiblePaperInfo;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _inputManager.Controls.Player.Action.started += OnAction;
    }

    private void OnDestroy()
    {
        _inputManager.Controls.Player.Action.started -= OnAction;
    }

    private void OnAction(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_collectiblePaperInfo.PaperSelected)
            _gameManager.CollectPaper(_collectiblePaperInfo.Paper);
    }
}
