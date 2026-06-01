using UnityEngine;

public class SlidingDoor : Door
{
    [SerializeField] private Vector3 _openPosition;
    [SerializeField] private Vector3 _closePosition;

    public override void Open()
    {
        base.Open();
    }

    public override void Close()
    {
        base.Close();
    } 

}
