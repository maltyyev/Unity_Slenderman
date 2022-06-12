using UnityEngine;

public class PlayerPaperRaycast : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private CollectiblePaperInfo _collectiblePaperInfo;

    private Ray _ray;
    private RaycastHit _raycastHist;

    private void FixedUpdate()
    {
        _ray = _playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(_ray, out _raycastHist, _raycastDistance, _layerMask))
        {
            _collectiblePaperInfo.PaperSelected = true;
            _collectiblePaperInfo.Paper = _raycastHist.transform.gameObject;
        }
        else
        {
            _collectiblePaperInfo.PaperSelected = false;
            _collectiblePaperInfo.Paper = null;
        }
    }
}
