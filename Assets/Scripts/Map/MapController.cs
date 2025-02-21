using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapController : MonoBehaviour
{
    private IMapGenerator mapGenerator;
    public static iMapData mapData { get; private set; }

    [SerializeField] private GameObject MapObj;

    public void Init(IMapGenerator _mapGenerator, iMapData _mapData)
    {
        mapGenerator = _mapGenerator;

        mapData = _mapData;

        GameStateMachine.GameModeChanged += StateMachineHandler;
    }

    private void StateMachineHandler(GameMode gm)
    {
        switch (gm)
        {
            case GameMode.Default:
                mapData.TurnOff();
                break;
            case GameMode.Game:
                mapData.TurnOn();
                break;
        }
    }

    private void OnDestroy()
    {
        GameStateMachine.GameModeChanged -= StateMachineHandler;
    }
}
