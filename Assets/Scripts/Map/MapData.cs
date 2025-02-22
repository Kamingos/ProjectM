using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapData : MonoBehaviour, iMapData
{
    private GameObject mapObj;

    public void Init(GameObject _mapObj)
    {
        mapObj = _mapObj;
    }

    public void TurnOff()
    {
        mapObj.GetComponent<NavMeshSurface>().enabled = false;
    }

    public void TurnOn()
    {
        mapObj.GetComponent<NavMeshSurface>().enabled = true;
    }

    public Vector3 GetMapCenter()
    {
        return mapObj.GetComponent<TerrainCollider>().bounds.size/2;
    }
}
