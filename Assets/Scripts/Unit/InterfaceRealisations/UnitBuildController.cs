using System;
using System.Collections;
using UnityEngine;

public class UnitBuildController : MonoBehaviour, IBuildSystem
{

    public event Action<bool> BtnPressEvent;

    public void ClearEvent()
    {
        BtnPressEvent = null;
    }

    public void TurnOn()
    {
        StartCoroutine(Process());
    }

    public

    IEnumerator Process()
    {

        while (true)
        {
            transform.position = Pointer.pointerPos;

            if (Input.GetMouseButtonDown(0))
            {
                BtnPressEvent.Invoke(true);
                StopAllCoroutines();
            }
            if (Input.GetMouseButtonDown(1))
            {
                BtnPressEvent.Invoke(false);
                StopAllCoroutines();
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
