using UnityEngine;
using UnityEngine.AddressableAssets;

public class UCMaksim : AbstractUnitCreator
{
    string modelPath = "maxBone";

    public override Unit CreateUnit(GameObject parentObj, UnitType unitType)
    {
        SpinController sc = parentObj.AddComponent<SpinController>();
        UnitBuildController bc = parentObj.AddComponent<UnitBuildController>();

        SideController sdc = parentObj.AddComponent<SideController>();
        //...

        Unit unit = new Unit();

        unit.Init(_controller: sc, _damage: null, _onDied: null, _unitHealth: null, _buildSystem: bc, _sideController: sdc, _type: unitType);

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
        model.GetComponent<BoxCollider>().size = new Vector3(2, 10, 2);
        model.GetComponent<BoxCollider>().center = new Vector3(0, 5, 0);

        // прочее
        model.layer = 2;

        return model;
    }
}
