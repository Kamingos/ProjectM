using System;
using UnityEngine;

public class UnitBuildController : MonoBehaviour, IBuildSystem
{
    ISideController sideController;

    public event Action<bool> BtnPressEvent;
    
    private Material material;
    private BoxCollider boxCollider;

    Color colorRed = new Color(1, 0f, 0f);

    public Vector3 StartPos { get; private set; }
    public static bool canBuild { get; private set; } = true;

    private bool builded = false;
    
    public void ClearEvent()
    {
        BtnPressEvent = null;
    }

    public void Init(ISideController _sideController) 
    {
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        boxCollider = GetComponent<BoxCollider>();

        sideController = _sideController;

        sideController.TurnOn();
    }

    void Update()
    {
        if (builded) return;

        transform.position = Pointer.pointerPos;

        if (CollidersChecking())
        {
            if (Input.GetMouseButtonDown(0))
            {
                sideController.SetSide();
                BtnPressEvent.Invoke(true);
                builded = true;

                StartPos = transform.position;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            BtnPressEvent.Invoke(false);
            builded = false;
        }
    }

    private bool CollidersChecking()
    {
        if (Physics.OverlapSphere(transform.position, boxCollider.size.x * 0.75f, 1 << 2)?.Length > 1)
        {
            canBuild = false;
            material.color = colorRed;
            if (sideController.GetSide() != "") sideController.SetSide();
            return false;
        }

        canBuild = true;
        return true;
    }

    public void SetStartPos()
    {
        //gameObject.GetComponent<NavMeshAgent>().enabled = false;
        transform.position = StartPos;
    }
}
