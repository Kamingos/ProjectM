using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AI;

public class UCRei : AbstractUnitCreator
{
    string modelPath = "PlushRei";
    string animController = "Test";

    // ������� ��� ��������
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

        healthController.Init(100f,hbc,null, dc);
        gub.Init(5f, 10f, 1.5f);
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

        // ���������� �����������
        //rb =model.AddComponent<Rigidbody>();
        bc = model.AddComponent<BoxCollider>();
        nma = model.AddComponent<NavMeshAgent>();
        animator = model.transform.GetChild(0).AddComponent<Animator>();

        // ��������� RB
        //rb.freezeRotation = true;
        //rb.isKinematic = true;

        // ��������� NavMeshAgent
        nma.speed = 10f;
        nma.radius = 1f;
        nma.stoppingDistance = nma.radius + 0.2f;
        nma.height = 5f;
        nma.angularSpeed = 180f;
        nma.acceleration = 50f;


        // ��������� BoxCollider
        bc.size = new Vector3(2, 5, 2);
        bc.center = new Vector3(0, 2.5f, 0);

        // ��������� Animator
        animator.runtimeAnimatorController = animController;

        // ������
        model.layer = 2;

        return model;
    }
}
