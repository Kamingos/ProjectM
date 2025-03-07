using UnityEngine;

public class GameController : MonoBehaviour
{
    private UnitController unitController;
    private GameUIController gameUIController;
    private MapController mapController; //TODO

    public void Init(UnitController _unitController, GameUIController _gameUIController, MapController _mapController)
    {
        unitController = _unitController;
        gameUIController = _gameUIController;
        mapController = _mapController;

        GameStateMachine.OnRestartLevel += RestartLevel;
        gameUIController.OnBtnPressed += CreateUnit;

        // ��� �����
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
        cube.transform.position = MapController.mapData.GetMapCenter();
    }

    private void Update()
    {
        if (GameStateMachine.CurrentGameMode == GameMode.Default)
        {
            if (Input.GetMouseButtonDown(3) || Input.GetKeyDown(KeyCode.R))
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

    private void RestartLevel()
    {
        unitController.ResetUnits();
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
