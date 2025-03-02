using System.Collections;
using UnityEngine;

public class SideController : MonoBehaviour, ISideController
{
    private Material material;
    private string side = "";

    private bool flag = true;

    private Color colorLeft  = new Color(0.5f, 0.7f, 1);
    private Color colorRight = new Color(1f, 0.7f, 0.5f);

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
        if (!flag) return;

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
            flag = false;

            SetSide(true);
        }
    }
    public void SetSide(bool spec)
    {
        if (transform.position.x <= MapController.mapData.GetMapCenter().x)
        {
            material.color = colorLeft;
            transform.eulerAngles = Vector3.up * 90f;
        }
        else
        {
            material.color = colorRight;
            transform.eulerAngles = Vector3.down * 90f;
        }
    }

    public string GetSide()
    {
        return side;
    }

    public void ResetSide()
    {
        side = "";
        flag = true;
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
                transform.eulerAngles = Vector3.up * 90f;
            }
            else
            {
                material.color = colorRight;
                transform.eulerAngles = Vector3.down * 90f;
            }

        }
        //yield return new WaitForSeconds(Time.deltaTime);

    }


}
