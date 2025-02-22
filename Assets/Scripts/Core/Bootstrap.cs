using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    // Сериализуемые
    [SerializeField] private Transform CoursorPos;
    [SerializeField] private Transform unitsParent;

    [SerializeField] private Pointer pointer;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameUIView gameUIView;
    [SerializeField] private MapController mapController;

    // Создавааемые
    private PointerHandler pointHandler;
    private UCController UCC;
    private BuildController buildController;
    private UnitController unitController;
    private GameUIController gameUIController;
    private MapData mapData;
    private MapGenerator mapGenerator;


    private void Awake()
    {
        // #0

        // #1
        UCC = new UCController();
        UCC.Init(unitsParent);

        // #2
        buildController = new BuildController();
        buildController.Init(UCC);

        // #3
        unitController = new UnitController();
        unitController.Init(buildController);

        // Game UI-->
        gameUIView.Init();

        gameUIController = new GameUIController();
        gameUIController.Init(gameUIView);
        // Game UI<--

        // Map -->

        mapData = new MapData();
        mapGenerator = new MapGenerator();

        mapController.Init(mapGenerator, mapData);
        // Map <--

        // #4
        gameController.Init(unitController, gameUIController, mapController);

        // #5
        pointHandler = new PointerHandler();
        pointHandler.Init(CoursorPos);

        // #6
        pointer.Init(pointHandler);

        // #end
        GameStateMachine.SetDefaultMode();
    }
}
