using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UCController : MonoBehaviour
{   
    GameObject unitModel;
    AbstractUnitCreator controller;
    Unit unit;

    int a = 0;

    public GameObject CreateUnit(UnitType type)
    {
        switch (type)
        {
            case UnitType.Maksim:
                if (controller==null) controller = new UCMaksim();
                break;
            case UnitType.Rei:
                break;
            default:
                break;
        }

        unitModel = controller.CreateModel();

        unit = controller.CreateUnit(unitModel);

        unitModel.AddComponent<Unit>();

        unitModel.GetComponent<Unit>().Copy(unit);

        a++;
        return unitModel;
    }
}
