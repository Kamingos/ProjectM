using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GroundUnitBehaviour : AbstractUnitBehaviour
{
    private GameObject target;
    private HealthController targetHealth;

    protected override void TurnOn()
    {
        StartCoroutine(GameCycle());
    }

    protected override void TurnOff()
    {
        StopAllCoroutines();
    }

    IEnumerator GameCycle()
    {
        while (true)
        {
            target = UnitController.TargetSearcher.FindTarget(FinderType.Random,
                    (GetComponent<SideController>().GetSide() == "Left")
                    ? UnitController.UnitsRight
                    : UnitController.UnitsLeft,
                    transform.position);

            if (!target) { yield return new WaitForSeconds(2f); break; }

            targetHealth = target.GetComponent<HealthController>();

            do
            {
                if (!target.activeSelf) break;

                SetDuration(target.transform.position);

                yield return new WaitForSeconds(1f);
            }
            while (Vector2.Distance(transform.position, navAgent.destination) >= attackRange);

            if (!target.activeSelf) continue;

            while (targetHealth.Health > 0f)
            {
                targetHealth.Health = targetHealth.Health - dammageValue;

                if (Vector2.Distance(transform.position, navAgent.destination) >= attackRange) break;

                yield return new WaitForSeconds(attackSpeed);
            }

            yield return new WaitForSeconds(2f);
        }
    }




}
