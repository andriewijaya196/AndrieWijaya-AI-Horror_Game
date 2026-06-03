using UnityEngine;

public class InteractDetector : MonoBehaviour
{
    [SerializeField] private PlayerCharacter _owner;
    [SerializeField] private float _detectorDistance;
    [SerializeField] private Vector3 _detectorBoxSize = Vector3.one;
    [SerializeField] private LayerMask _interactableLayer;
    private GameObject _detectedInteractable;
    private bool _isInteracting;
    
    private void OnDrawGizmos()
    {
        Transform cameraTransform = Camera.main.transform;
        Gizmos.color = Color.red;
        bool isDetectingInteractable = Physics.BoxCast(cameraTransform.position, _detectorBoxSize * 0.5f, cameraTransform.forward, out RaycastHit hit, Quaternion.identity, _detectorDistance, _interactableLayer);
        if (isDetectingInteractable)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(cameraTransform.position, cameraTransform.position + cameraTransform.forward * hit.distance);
            Gizmos.DrawWireCube(cameraTransform.position + cameraTransform.forward * hit.distance, _detectorBoxSize);
        }
        else
        {
            Gizmos.DrawLine(cameraTransform.position, cameraTransform.position + cameraTransform.forward * _detectorDistance);
            Gizmos.DrawWireCube(cameraTransform.position + cameraTransform.forward * _detectorDistance, _detectorBoxSize);
        }
    }

}