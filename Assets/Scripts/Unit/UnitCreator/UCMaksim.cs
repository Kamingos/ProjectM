using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AI;

public class UCMaksim : AbstractUnitCreator
{
    string modelPath = "maxBone";
    string animController = "Test";

    // кэширую для удобства
    Rigidbody rb;
    BoxCollider bc;
    NavMeshAgent nma;
    Animator animator;

    public override Unit CreateUnit(GameObject parentObj, UnitType unitType)
    {
        GroundUnitBehaviour gub = parentObj.AddComponent<GroundUnitBehaviour>();

        UnitBuildController bc = parentObj.AddComponent<UnitBuildController>();
        SideController sdc = parentObj.AddComponent<SideController>();

        HealthController healthController = parentObj.AddComponent<HealthController>();
        HealthBarController hbc = parentObj.AddComponent<HealthBarController>();
        DamageController daC = parentObj.AddComponent<DamageController>();
        DeathController deC = parentObj.AddComponent<DeathController>();

        healthController.Init(100f, hbc, daC, deC);
        gub.Init(2.5f, 10f, 1.5f);
        bc.Init(sdc);
        //...

        Unit unit = new Unit();

        unit.Init(_controller: gub, _unitHealth: healthController, _buildSystem: bc, _type: unitType);

        return unit;
    }

    public override GameObject CreateModel()
    {
        var modelHandle = Addressables.LoadAssetAsync<GameObject>(modelPath);
        var AnimHandle = Addressables.LoadAssetAsync<RuntimeAnimatorController>(this.animController);

        modelHandle.WaitForCompletion();
        AnimHandle.WaitForCompletion();

        GameObject model = Instantiate(modelHandle.Result, Vector3.zero, Quaternion.identity);
        RuntimeAnimatorController animController = AnimHandle.Result;

        // добавление компонентов
        bc = model.AddComponent<BoxCollider>();
        nma = model.AddComponent<NavMeshAgent>();
        animator = model.transform.GetChild(0).AddComponent<Animator>();

        // настройки NavMeshAgent
        nma.speed = 10f;
        nma.radius = 1f;
        nma.stoppingDistance = nma.radius + 0.2f;
        nma.height = 10f;
        nma.angularSpeed = 180f;
        nma.acceleration = 50f;

        // настройки BoxCollider
        bc.size = new Vector3(2, 10, 2);
        bc.center = new Vector3(0, 5, 0);

        // настройки Animator
        animator.runtimeAnimatorController = animController;

        // прочее
        model.layer = 2;

        return model;
    }
}
