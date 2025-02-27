using UnityEngine;
using UnityEngine.AI;

abstract public class AbstractUnitBehaviour : MonoBehaviour, IUnitController
{
    protected NavMeshAgent navAgent;
    protected float attackRange;
    protected float dammageValue;
    protected float attackSpeed;

    virtual public void Init(float _attackRange, float _dammageValue, float _attackSpeed)
    {
        attackRange = _attackRange;
        dammageValue = _dammageValue;
        attackSpeed = _attackSpeed;

        navAgent = this.GetComponent<NavMeshAgent>();

        GameStateMachine.GameModeChanged += GameStateMachineHandler;
    }

    abstract protected void GameStateMachineHandler(GameMode gm);

    virtual public void OnDied()
    {
        throw new System.NotImplementedException();
    }

    protected bool SetDuration(Vector3 pos)
    {
        if (GameStateMachine.CurrentGameMode == GameMode.Game) {navAgent.SetDestination(pos); return true; }
        return false;
    }

    abstract protected void OnDestroy();

}
