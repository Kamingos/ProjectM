using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIView : MonoBehaviour
{
    [SerializeField] private List<Button> btns;

    [SerializeField] private List<Image> pnls;

    [SerializeField] private TMP_Text statusText;

    public event Action<int> OnBtnPressed;

    public void Init()
    {
        for (int i = 0; i < btns.Count; i++)
        {
            int id = i;
            btns[i].onClick.AddListener(() => { 
                //Debug.Log(i); 
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

    public void SetStatus(GameMode gameMode)
    {
        switch (gameMode)
        {
            case GameMode.Nothing:
                statusText.text = "Nothing";
                break;
            case GameMode.Default:
                statusText.text = "Default";
                break;
            case GameMode.Pause:
                statusText.text = "Pause";
                break;
            case GameMode.Editing:
                statusText.text = "Editing";
                break;
            case GameMode.Game:
                statusText.text = "Game";
                break;
        }

    }
}
