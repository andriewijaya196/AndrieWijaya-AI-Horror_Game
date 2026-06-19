using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private StaminaUI _staminaUI;
    [SerializeField] private BatteryLevelUI _batteryLevelUI;
    [SerializeField] private InteractionInfoUi _interactionInfoUI;
    [SerializeField] private CrosshairUI _crosshairUI;

    private static HUDManager _instance;
    public static HUDManager Instance => _instance;
    public StaminaUI StaminaUI => _staminaUI;
    public BatteryLevelUI BatteryLevelUI => _batteryLevelUI;
    public InteractionInfoUi InteractionInfoUI => _interactionInfoUI;
    public CrosshairUI CrosshairUI => _crosshairUI;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
}
