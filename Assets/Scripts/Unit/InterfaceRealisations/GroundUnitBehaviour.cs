using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GroundUnitBehaviour : AbstractUnitBehaviour
{
    GameObject target;
    HealthController targetHealth;

    private void TurnOn()
    {
        StartCoroutine(GameCycle());
    }

    private void TurnOff()
    {
        gameObject.GetComponent<IBuildSystem>().SetStartPos();
        StopAllCoroutines();
    }

    protected override void GameStateMachineHandler(GameMode gm)
    {
        switch (gm)
        {
            case GameMode.Game:
                navAgent.enabled = true;
                TurnOn();
                break;
            case GameMode.Default:
                navAgent.enabled = false;
                TurnOff();
                break;
        }
    }

    IEnumerator GameCycle()
    {
        while (true)
        {
            target = UnitController.TargetSearcher.FindTarget(FinderType.Nearest,
                    (GetComponent<SideController>().GetSide() == "Left")
                    ? UnitController.UnitsRight
                    : UnitController.UnitsLeft,
                    transform.position);

            targetHealth = target.GetComponent<HealthController>();

            while (Vector3.Distance(transform.position, target.transform.position) > attackRange)
            {
                SetDuration(target.transform.position);

                yield return new WaitForSeconds(0.7f);
            }

            while (targetHealth.Health > 0)
            {
                targetHealth.Health -= dammageValue;

                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }


    protected override void OnDestroy()
    {
        //Pointer.clickEvent -= SetDuration;

        GameStateMachine.GameModeChanged -= GameStateMachineHandler;
    }
}
