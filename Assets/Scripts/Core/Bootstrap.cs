using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] Transform CoursorPos;

    [SerializeField] private Pointer pointer;

    private PointerHandler pointHandler;
    private UCController UCC;

    private void Awake()
    {
        UCC = new UCController();
        UCC.Init();

        pointHandler = new PointerHandler();
        pointHandler.Init(UCC, CoursorPos);

        pointer.Init(pointHandler);
    }
}
