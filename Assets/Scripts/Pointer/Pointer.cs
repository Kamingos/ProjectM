using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Camera camera;
    private IPointerHandler pointerHandler;

    private void Awake()
    {
        pointerHandler = GetComponent<IPointerHandler>();
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Beacon();
    }

    private void Beacon()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            pointerHandler.DoAction(hit.point);
        }
    }
}
