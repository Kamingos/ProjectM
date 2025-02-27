using System;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    private UCController _UCController;
    public event Action<GameObject, string> ReturnUnitEvent;
    public event Action<UnitType> CreateUnitEvent;

    private GameObject unitTemp;

    public void Init(UCController UCC)
    {
        _UCController = UCC;
    }
    
    public void CreateUnit(UnitType unitType)
    {
        unitTemp = _UCController.CreateUnit(unitType);

        GameStateMachine.SetEditingMode();

        unitTemp.GetComponent<UnitBuildController>().BtnPressEvent += (bool answ) =>
        {
            unitTemp.GetComponent<UnitBuildController>().ClearEvent();
            if (answ)
            {
                ReturnUnitEvent.Invoke(unitTemp, unitTemp.GetComponent<SideController>().GetSide());
                CreateUnitEvent.Invoke(unitType);
            }
            else
            {
                Destroy(unitTemp);
                GameStateMachine.SetDefaultMode();
            }
            
        };
    }

}
