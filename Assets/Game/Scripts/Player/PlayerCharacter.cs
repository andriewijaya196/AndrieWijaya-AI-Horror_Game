using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private PlayerCharacterMovement _movement;
    [SerializeField] private PlayerCharacterStamina _stamina;
    [SerializeField] private InventoryManager _inventory;
    [SerializeField] private InteractDetector _interactDetector;
    [SerializeField] private CameraManager _camera;
    [SerializeField] private InputManager _input;
    [SerializeField] private Flashlight _flashlight;

    public UnityEvent OnDeath;

    public PlayerCharacterMovement Movement => _movement;
    public PlayerCharacterStamina Stamina => _stamina;
    public InventoryManager Inventory => _inventory;
    public InteractDetector InteractDetector => _interactDetector;
    public CameraManager Camera => _camera;
    public InputManager input => _input;
    public Flashlight Flashlight => _flashlight;
    public bool IsHiding { get; private set;}

    public void SetIsHiding(bool isHiding)
    {
        IsHiding = isHiding;
    }
    
    public void Death()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        OnDeath?.Invoke();

    }

     public void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   

}