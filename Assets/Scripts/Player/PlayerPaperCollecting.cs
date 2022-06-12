using UnityEngine;

public class PlayerPaperCollecting : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _layerMask;

    private Ray _ray;
    private RaycastHit _raycastHist;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _ray = _playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(_ray, out _raycastHist, _raycastDistance, _layerMask))
        {
            _raycastHist.transform.gameObject.SetActive(false);
        }
    }
}
