using System.Collections.Generic;
using UnityEngine;

public interface ITargetSearcher
{
    public GameObject FindTarget(FinderType findType, List<GameObject> list, Vector3 position);
}
