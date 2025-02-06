using UnityEngine;

public class PointerHandler : MonoBehaviour, IPointerHandler
{
    UCController controller;
    
    private Transform coursorPos;
    public void Init(UCController ucc, Transform _coursorPos)
    {
        controller = ucc;
        coursorPos = _coursorPos;
    }

     public void DoAction(Vector3 pos)
    {
        coursorPos.position = pos;

        if (Input.GetMouseButton(0))
        {
            controller.CreateUnit(UnitType.Maksim, pos);
        }            
    }
}
