using System.Collections;
using UnityEngine;

public class SideController : MonoBehaviour, ISideDependence
{
    private Material material;
    private string side = "";

    private bool flag = true;

    public Color colorBlue { get; private set; } = new Color(0.6f, 0.6f, 1);
    public Color colorGreen { get; private set; } = new Color(0.6f, 1, 0.6f);

    public void StopUpdate()
    {
        flag = false;
    }

    public void TurnOn()
    {
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;

        StartCoroutine(process());
    }


    public void SetSide(bool var)
    {
        if (var && flag)
        {
            if (side == "")
            {
                if (transform.position.x <= MapController.mapData.GetMapCenter().x)
                {
                    side = "Blue";
                }
                else
                {
                    side = "Red";
                }
                flag = false;
            }
        }
    }

    public string GetSide()
    {
        return side;
    }

    IEnumerator process()
    {
        while (flag)
        {
            if (UnitBuildController.canBuild)
            {
                if (transform.position.x <= MapController.mapData.GetMapCenter().x)
                {
                    material.color = colorBlue;
                }
                else
                {
                    material.color = colorGreen;
                }

            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }


}
