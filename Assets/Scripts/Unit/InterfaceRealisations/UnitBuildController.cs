using System;
using UnityEngine;
using UnityEngine.AI;

public class UnitBuildController : MonoBehaviour, IBuildSystem
{
    public event Action<bool> BtnPressEvent;
    
    private Material material;
    private BoxCollider boxCollider;

    Color colorRed = new Color(1, 0.4f, 0.4f);

    public Vector3 StartPos { get; private set; }
    public static bool canBuild { get; private set; } = true;

    private bool builded = false;
    
    public void ClearEvent()
    {
        BtnPressEvent = null;
    }

    public void TurnOn()
    {
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        boxCollider = GetComponent<BoxCollider>();
        //StartCoroutine(Process());
    }

    void Update()
    {
        if (!builded)
        {
            transform.position = Pointer.pointerPos;

            if (CollidersChecking())
            {
                if (Input.GetMouseButtonDown(0))
                {
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
    }

    private bool CollidersChecking()
    {
        if (Physics.OverlapSphere(transform.position, boxCollider.size.x * 0.75f, 1 << 2)?.Length > 1)
        {
            canBuild = false;
            material.color = colorRed;
            
            return false;
        }

        canBuild = true;
        return true;
    }

    public void SetStartPos()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        transform.position = StartPos;
    }
}
