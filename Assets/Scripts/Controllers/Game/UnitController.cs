using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private BuildController buildController;

    private List<GameObject> units;

    public void Init(BuildController _buildController)
    {
        buildController = _buildController;

        units = new List<GameObject>();

        buildController.ReturnUnitEvent += (_) => { units.Add(_); };
        buildController.CreateUnitEvent += (_) => { CreateUnit(_); }; 
    }
    
    public void CreateUnit(UnitType unitType)
    {
        buildController.CreateUnit(unitType);
    }

    public void ClearUnits()
    {
        foreach (var item in units)
        {
            Destroy(item);
            
        }
        units.Clear();
    }
}
