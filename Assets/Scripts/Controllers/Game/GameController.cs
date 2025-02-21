using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private UnitController unitController;
    private GameUIController gameUIController;
    private MapController mapController;

    public void Init(UnitController _unitController, GameUIController _gameUIController, MapController _mapController)
    {
        unitController = _unitController;
        gameUIController = _gameUIController;
        mapController = _mapController;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStateMachine.SetGameMode();
            }
        }
        else if (GameStateMachine.CurrentGameMode == GameMode.Game)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStateMachine.SetDefaultMode();
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
