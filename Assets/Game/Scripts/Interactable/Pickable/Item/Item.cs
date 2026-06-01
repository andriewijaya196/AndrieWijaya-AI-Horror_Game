using UnityEngine;

public class Item : MonoBehaviour, IInteractable, IPickable
{
    [SerializeField] public string _name;
    public string Name => _name;

    public void Interact()
    {
        PickUp();
    }

    public void PickUp()
    {
        
    }
}