using UnityEngine;
using UnityEngine.AddressableAssets;

public class UCMaksim : AbstractUnitCreator
{
    string modelPath = "Assets/Models/maxBone.fbx";

    public override Unit CreateUnit(GameObject parentObj)
    {
        SpinController sc = parentObj.AddComponent<SpinController>();
        //...

        Unit unit = new Unit();

        unit.Init(_controller: sc, _damage: null, _onDied: null, _unitHealth: null);

        return unit;
    }

    public override GameObject CreateModel(Vector3 pos)
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(modelPath);

        handle.WaitForCompletion();

        GameObject model = Instantiate(handle.Result, pos, Quaternion.identity);

        model.AddComponent<Rigidbody>();
        model.AddComponent<BoxCollider>();

        model.GetComponent<Rigidbody>().freezeRotation = true;

        model.GetComponent<BoxCollider>().size = new Vector3(2, 10, 2);
        model.GetComponent<BoxCollider>().center = new Vector3(0, 5, 0);


        return model;
    }
}
