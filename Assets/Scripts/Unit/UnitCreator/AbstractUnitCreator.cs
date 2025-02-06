using UnityEngine;

abstract public class AbstractUnitCreator : MonoBehaviour
{
    abstract public Unit CreateUnit(GameObject parentObj);

    abstract public GameObject CreateModel(Vector3 pos);
}
