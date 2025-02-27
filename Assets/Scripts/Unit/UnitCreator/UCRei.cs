using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AI;

public class UCRei : AbstractUnitCreator
{
    string modelPath = "PlushRei";
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
        DeathController dc = parentObj.AddComponent<DeathController>();

        healthController.Init(100f,hbc);
        gub.Init(2f, 10f, 1.5f);
        //...

        Unit unit = new Unit();

        unit.Init(_controller: gub, _damage: null, _deathCtontroller: dc, _unitHealth: healthController, _buildSystem: bc, _sideController: sdc, _type: unitType);

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
        rb =model.AddComponent<Rigidbody>();
        bc = model.AddComponent<BoxCollider>();
        nma = model.AddComponent<NavMeshAgent>();
        animator = model.transform.GetChild(0).AddComponent<Animator>();

        // настройки RB
        rb.freezeRotation = true;
        rb.isKinematic = true;

        // настройки NavMeshAgent
        nma.speed = 10f;
        nma.stoppingDistance = 0.2f;
        nma.radius = 1f;
        nma.height = 5f;

        // настройки BoxCollider
        bc.size = new Vector3(2, 5, 2);
        bc.center = new Vector3(0, 2.5f, 0);

        // настройки Animator
        animator.runtimeAnimatorController = animController;

        // прочее
        model.layer = 2;

        return model;
    }
}
