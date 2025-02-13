using UnityEngine;

public class PointerHandler : MonoBehaviour, IPointerHandler
{
    
    private Transform coursorPos;
    public void Init(Transform _coursorPos)
    {
        coursorPos = _coursorPos;
    }

     public void DoAction(Vector3 pos)
    {
        coursorPos.position = pos;       
    }
}
