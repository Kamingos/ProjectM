using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UCController : MonoBehaviour
{
    List<GameObject > list = new List<GameObject>();
    
    GameObject unitModel;
    AbstractUnitCreator controller;
    Unit unit;

    int a = 0;
    public void Init()
    {

    }

    public void CreateUnit(UnitType type, Vector3 pointerPos)
    {
        switch (type)
        {
            case UnitType.Maksim:
                if (controller==null)
                {
                    controller = new UCMaksim();
                }
                break;
            case UnitType.Rei:
                break;
            default:
                break;
        }

        

        unitModel = controller.CreateModel(pointerPos);

        unit = controller.CreateUnit(unitModel);

        unitModel.AddComponent<Unit>();

        unitModel.GetComponent<Unit>().Copy(unit);

        a++;
        return;
    }
}
