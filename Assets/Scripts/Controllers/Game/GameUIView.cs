using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIView : MonoBehaviour
{
    [SerializeField] private List<Button> btns;

    [SerializeField] private List<Image> pnls;

    public event Action<int> OnBtnPressed;

    public void Init()
    {
        for (int i = 0; i < btns.Count; i++)
        {
            int id = i;
            btns[i].onClick.AddListener(() => { 
                Debug.Log(i); 
                OnBtnPressed.Invoke(id);
            });
        }
    }

    public void ChangePanelColor(int i)
    {
        foreach (var item in pnls)
        {
            item.color = new Color(0.3f, 0.3f, 0.3f, 0.5f);
        }

        if (i>=0) pnls[i].color = new Color(0.3f, 1f, 0.3f, 0.5f);
    }
}
