using UnityEngine;

public class MapGenerator : MonoBehaviour, IMapGenerator
{
    public GameObject MapGenerate()
    {
        return GameObject.FindGameObjectWithTag("Terrain");
    }

}
