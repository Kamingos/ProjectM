using UnityEngine;
using UnityEngine.AddressableAssets;

public class UCRei : AbstractUnitCreator
{
    string modelPath = "Assets/Models/PlushRei.fbx";

    public override Unit CreateUnit(GameObject parentObj)
    {
        SpinController sc = parentObj.AddComponent<SpinController>();
        UnitBuildController bc = parentObj.AddComponent<UnitBuildController>();
        //...

        Unit unit = new Unit();

        unit.Init(_controller: sc, _damage: null, _onDied: null, _unitHealth: null, _buildSystem: bc);

        return unit;
    }

    public override GameObject CreateModel()
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(modelPath);

        handle.WaitForCompletion();

        GameObject model = Instantiate(handle.Result, Vector3.zero, Quaternion.identity);

        // добавление компонентов
        model.AddComponent<Rigidbody>();
        model.AddComponent<BoxCollider>();

        // настройки RB
        model.GetComponent<Rigidbody>().freezeRotation = true;
        model.GetComponent<Rigidbody>().isKinematic = true;

        // настройки BoxCollider
        model.GetComponent<BoxCollider>().size = new Vector3(2, 5, 2);
        model.GetComponent<BoxCollider>().center = new Vector3(0, 2.5f, 0);

        // прочее
        model.layer = 2;

        return model;
    }
}
