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

    public override Unit CreateUnit(GameObject parentObj)
    {
        TestController sc = parentObj.AddComponent<TestController>();
        UnitBuildController bc = parentObj.AddComponent<UnitBuildController>();
        //...

        Unit unit = new Unit();

        unit.Init(_controller: sc, _damage: null, _onDied: null, _unitHealth: null, _buildSystem: bc);

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
        rb =model.AddComponent<Rigidbody>();
        bc = model.AddComponent<BoxCollider>();
        nma = model.AddComponent<NavMeshAgent>();
        animator = model.transform.GetChild(0).AddComponent<Animator>();

        // ��������� RB
        rb.freezeRotation = true;
        rb.isKinematic = true;

        // ��������� NavMeshAgent
        nma.speed = 10f;
        nma.stoppingDistance = 0.2f;
        nma.radius = 1f;
        nma.height = 5f;

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
