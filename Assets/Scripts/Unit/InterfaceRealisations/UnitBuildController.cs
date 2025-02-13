using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitBuildController : MonoBehaviour, IBuildSystem
{
    private bool isBuilded = false;

    public event Action<bool> BtnPressEvent;

    public void ClearEvent()
    {
        BtnPressEvent = null;
    }

    private void Update()
    {
        if (!isBuilded)
        {
            transform.position = Pointer.pointerPos;

            if (Input.GetMouseButtonDown(0))
            {
                BtnPressEvent.Invoke(true);
                isBuilded = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                BtnPressEvent.Invoke(false);
                isBuilded = true;
            }
        }
    }
}
