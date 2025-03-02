using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetSearcher : MonoBehaviour, ITargetSearcher
{
    private Vector3 temp;
    private List<GameObject> listTemp;
    public GameObject FindTarget(FinderType findType, List<GameObject> list, Vector3 position)
    {
        switch (findType)
        {
            case FinderType.Nearest:
                return NearestFind(list, position);
                break;
            case FinderType.Further:
                return FurtherFind(list, position);
                break;
            case FinderType.Largest:
                break;
            case FinderType.Smallest:
                break;
            case FinderType.Random:
                return RandomFind(list, position);
                break;
        }
        return null;
    }

    private GameObject NearestFind(List<GameObject> list, Vector3 position)
    {
        listTemp = list.Where(x => x.activeSelf).ToList();
        listTemp = listTemp.OrderBy(x => Vector3.Distance(position, x.transform.position)).ToList();
        if (listTemp.Any()) return listTemp.First();
        return null;
    }

    private GameObject FurtherFind(List<GameObject> list, Vector3 position)
    {
        listTemp = list.Where(x => x.activeSelf).ToList();
        listTemp = listTemp.OrderBy(x => Vector3.Distance(position, x.transform.position)).ToList();
        if (listTemp.Any()) return listTemp.Last();
        return null;
    }

    private GameObject RandomFind(List<GameObject> list, Vector3 position)
    {
        listTemp = list.Where(x => x.activeSelf).ToList();
        if (listTemp.Any()) return listTemp[Random.Range(0, listTemp.Count)];
        return null;
    }
}
