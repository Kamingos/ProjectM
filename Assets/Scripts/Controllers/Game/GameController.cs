using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private UnitController unitController;
    private GameUIController gameUIController;

    public void Init(UnitController _unitController, GameUIController _gameUIController)
    {
        unitController = _unitController;
        gameUIController = _gameUIController;

        gameUIController.OnBtnPressed += CreateUnit;
    }

    private void Update()
    {
        if (GameStateMachine.CurrentGameMode == GameMode.Default)
        {
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    unitController.CreateUnit(UnitType.Maksim);
            //}
            if (Input.GetMouseButtonDown(3))
            {
                unitController.ClearUnits();
            }
        }
    }

    private void CreateUnit(int i)
    {
        unitController.CreateUnit((UnitType) i);
    }

    private void OnDestroy()
    {
        gameUIController.OnBtnPressed -= CreateUnit;
    }
}
