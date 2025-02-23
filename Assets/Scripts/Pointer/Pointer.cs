using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pointer : MonoBehaviour
{
    private Camera camera;
    private IPointerHandler pointerHandler;

    public static Vector3 pointerPos;

    public static event Action<Vector3> clickEvent;

    public void Init(IPointerHandler _pointerHandler)
    {
        pointerHandler = _pointerHandler;
        camera = GetComponent<Camera>();

        clickEvent += (_) => { };

        StartCoroutine(Checking());
    }

    IEnumerator Checking()
    {
        RaycastHit hit;
        while (true)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 2<<10,0b1))
            {
                pointerHandler.DoAction(hit.point);
                pointerPos = hit.point;
            }

            if (Input.GetMouseButtonDown(0))
            {
                clickEvent.Invoke(pointerPos);
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
