using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UCController : MonoBehaviour
{   
    GameObject unitModel;
    AbstractUnitCreator controller;
    Unit unit;
    Transform unitsParent;

    int a = 0;

    public void Init(Transform _unitsParent)
    {
        unitsParent = _unitsParent;
    }

    // TODO класс создаётся каждую итерацию. надо исправить
    public GameObject CreateUnit(UnitType type)
    {
        switch (type)
        {
            case UnitType.Maksim:
                if (controller==null) controller = new UCMaksim();
                break;
            case UnitType.Rei:
                if (controller == null) controller = new UCRei();
                break;
            default:
                break;
        }

        unitModel = controller.CreateModel();

        unit = controller.CreateUnit(unitModel, type);

        unitModel.AddComponent<Unit>();

        unitModel.GetComponent<Unit>().Copy(unit);

        unitModel.transform.SetParent(unitsParent);

        a++;
        return unitModel;
    }
}
