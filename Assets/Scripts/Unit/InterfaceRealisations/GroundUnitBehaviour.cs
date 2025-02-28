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
        gameObject.GetComponent<IBuildSystem>().SetStartPos();
        StopAllCoroutines();
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

                yield return new WaitForSeconds(attackSpeed);
            }

            yield return new WaitForSeconds(2f);
        }
    }




}
