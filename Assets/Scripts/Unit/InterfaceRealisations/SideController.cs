using System;
using System.Collections;
using UnityEngine;

public class SideController : MonoBehaviour, ISideDependence
{
    private Material material;
    private string side = "";

    public void StopUpdate()
    {
        StopAllCoroutines();
    }

    public void TurnOn()
    {
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;

        StartCoroutine(process());
    }

    public void SetSide(bool var)
    {
        if (var)
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
            }
        }
    }

    public string GetSide()
    {
        return side;
    }

    IEnumerator process()
    {
        while (true)
        {
            if (transform.position.x <= MapController.mapData.GetMapCenter().x)
            {
                material.color = new Color(0.6f, 0.6f, 1);
            }
            else
            {
                material.color = new Color(1, 0.6f, 0.6f);
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }


}
