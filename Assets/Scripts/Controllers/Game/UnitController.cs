using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private BuildController buildController;

    public static List<GameObject> UnitsLeft { get; private set; }
    public static List<GameObject> UnitsRight { get; private set; }

    public static TargetSearcher TargetSearcher;

    public void Init(BuildController _buildController)
    {
        buildController = _buildController;

        UnitsLeft = new List<GameObject>();
        UnitsRight = new List<GameObject>();

        TargetSearcher = new TargetSearcher();

        buildController.ReturnUnitEvent += (GameObject obj, string side) => 
        {
            if (side == "Left") UnitsLeft.Add(obj);
            else if (side == "Right") UnitsRight.Add(obj);
            else
            {
                Debug.LogError("передача неверной стороны в аргументе --> " + side);
            }
        };
        buildController.CreateUnitEvent += (_) => { CreateUnit(_); }; 
    }
    
    public void CreateUnit(UnitType unitType)
    {
        buildController.CreateUnit(unitType);
    }

    public void ClearUnits()
    {
        foreach (var item in UnitsLeft)
        {
            Destroy(item);
        }
        UnitsLeft.Clear();
        foreach (var item in UnitsRight)
        {
            Destroy(item);

        }
        UnitsRight.Clear();
    }

    public void ResetUnits()
    {
        foreach (var item in UnitsLeft)
        {
            item.SetActive(true);
            item.GetComponent<IBuildSystem>().SetStartPos();
            item.GetComponent<IHealth>().ResetHP();
            item.GetComponent<AbstractUnitBehaviour>().Reset();
        }
        foreach (var item in UnitsRight)
        {
            item.SetActive(true);
            item.GetComponent<IBuildSystem>().SetStartPos();
            item.GetComponent<IHealth>().ResetHP();
            item.GetComponent<AbstractUnitBehaviour>().Reset();
        }
    }
}
