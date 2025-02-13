using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    // Сериализуемые
    [SerializeField] Transform CoursorPos;
    [SerializeField] private Pointer pointer;
    [SerializeField] private GameController gameController;

    // Создавааемые
    private PointerHandler pointHandler;
    private UCController UCC;
    private BuildController buildController;
    private UnitController unitController;


    private void Awake()
    {
        // #0
        GameStateMachine.SetDefaultMode();

        // #1
        UCC = new UCController();

        // #2
        buildController = new BuildController();
        buildController.Init(UCC);

        // #3
        unitController = new UnitController();
        unitController.Init(buildController);

        // #4
        gameController.Init(unitController);

        // #5
        pointHandler = new PointerHandler();
        pointHandler.Init(CoursorPos);

        // #6
        pointer.Init(pointHandler);
    }
}
