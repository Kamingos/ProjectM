using UnityEngine;
using UnityEngine.AI;

public class TestController : MonoBehaviour, IUnitController
{
    private NavMeshAgent navAgent;

    public void TurnOn()
    {
        navAgent = this.GetComponent<NavMeshAgent>();

        Pointer.clickEvent += SetDuration;

        GameStateMachine.GameModeChanged += GameStateMachineHandler;
    }

    private void GameStateMachineHandler(GameMode gm)
    {
        switch (gm)
        {
            case GameMode.Game:
                navAgent.enabled = true;
                break;
            case GameMode.Default:
                gameObject.GetComponent<IBuildSystem>().SetStartPos();
                break;
        }
    }

    private void SetDuration(Vector3 pos)
    {
        if (GameStateMachine.CurrentGameMode == GameMode.Game) navAgent.SetDestination(pos);
    }

    void OnDestroy()
    {
        Pointer.clickEvent -= SetDuration;

        GameStateMachine.GameModeChanged -= GameStateMachineHandler;
    }
}
