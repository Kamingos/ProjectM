using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private UnitController unitController;

    public void Init(UnitController _unitController)
    {
        unitController = _unitController;
    }

    private void Update()
    {
        if (GameStateMachine.CurrentGameMode == GameMode.Default)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                unitController.CreateUnit(UnitType.Maksim);
            }
            if (Input.GetMouseButtonDown(3))
            {
                unitController.ClearUnits();
            }
        }
        else if (GameStateMachine.CurrentGameMode == GameMode.Editing)
        {

        }
    }
}
