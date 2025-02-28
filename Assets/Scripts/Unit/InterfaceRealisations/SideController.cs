using System.Collections;
using UnityEngine;

public class SideController : MonoBehaviour, ISideController
{
    private Material material;
    private string side = "";

    private bool flag = true;

    public Color colorLeft { get; private set; } = new Color(0.5f, 0.7f, 1);
    public Color colorRight { get; private set; } = new Color(1f, 0.7f, 0.5f);

    public void StopUpdate()
    {
        flag = false;
    }

    public void TurnOn()
    {
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;

        //StartCoroutine(process());
    }


    public void SetSide()
    {
        //if (flag)
        {
            if (side == "")
            {
                if (transform.position.x <= MapController.mapData.GetMapCenter().x)
                {
                    side = "Left";
                }
                else
                {
                    side = "Right";
                }
                //flag = false;
            }
        }
    }

    public string GetSide()
    {
        return side;
    }

    //IEnumerator process()
    private void Update()
    {
        if (!flag) return;

        if (UnitBuildController.canBuild)
        {
            if (transform.position.x <= MapController.mapData.GetMapCenter().x)
            {
                material.color = colorLeft;
            }
            else
            {
                material.color = colorRight;
            }

        }
        //yield return new WaitForSeconds(Time.deltaTime);

    }
}
