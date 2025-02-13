using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Camera camera;
    private IPointerHandler pointerHandler;

    public static Vector3 pointerPos;

    public void Init(IPointerHandler _pointerHandler)
    {
        pointerHandler = _pointerHandler;
        camera = GetComponent<Camera>();

        StartCoroutine(Checking());
    }

    IEnumerator Checking()
    {
        RaycastHit hit;
        while (true)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                pointerHandler.DoAction(hit.point);
                pointerPos = hit.point;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
