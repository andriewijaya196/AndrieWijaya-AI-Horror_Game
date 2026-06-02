using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour, IInteractable, IPickable
{
    [SerializeField] private ItemData _data;

    public UnityEvent OnItemPicked;
    public string Name => _data.Name;

    [ContextMenu("Interact Item")]

    public void Interact()
    {
        PickUp();
    }

    public void PickUp()
    {
        OnItemPicked?.Invoke();
        DestroyImmediate(gameObject);
    }
}