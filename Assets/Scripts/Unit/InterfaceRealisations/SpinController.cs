using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpinController : MonoBehaviour, IUnitController
{

    public void TurnOn()
    {
        StartCoroutine(Rotating());
    }

    IEnumerator Rotating()
    {
        while (true)
        {
            transform.Rotate(0f, 5f, 0f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
