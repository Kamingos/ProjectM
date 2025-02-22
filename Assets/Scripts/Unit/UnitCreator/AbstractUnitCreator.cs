using UnityEngine;

abstract public class AbstractUnitCreator : MonoBehaviour
{
    abstract public Unit CreateUnit(GameObject parentObj, UnitType unitType);

    abstract public GameObject CreateModel();
}
