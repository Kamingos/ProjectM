using UnityEngine;

public class PointerHandler : MonoBehaviour, IPointerHandler
{
    [SerializeField] Transform objPos;
     public void DoAction(Vector3 pos)
    {
        objPos.position = pos;

        if (Input.GetMouseButton(0))
        {

        }            
    }
}
