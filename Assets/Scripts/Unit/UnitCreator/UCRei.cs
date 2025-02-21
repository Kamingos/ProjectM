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
