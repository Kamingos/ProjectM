using UnityEngine;

public interface iMapData
{
    public void Init(GameObject mapObj);

    public void TurnOn();
    public void TurnOff();
    public Vector3 GetMapPosition();
}
