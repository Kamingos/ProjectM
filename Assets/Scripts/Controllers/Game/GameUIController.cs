using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    private GameUIView gameUIView;

    public event Action<int> OnBtnPressed;

    public void Init(GameUIView _gameUIView)
    {
        gameUIView = _gameUIView;

        gameUIView.OnBtnPressed += DoBtnAction;

        GameStateMachine.GameModeChanged += (_) => {if (_ == GameMode.Default) gameUIView.ChangePanelColor(-1); };
    }

    private void DoBtnAction(int BtnNum)
    {
        if (GameStateMachine.CurrentGameMode == GameMode.Default)
        {
            gameUIView.ChangePanelColor(BtnNum);
            OnBtnPressed.Invoke(BtnNum);
        }
    }

    private void OnDestroy()
    {
        gameUIView.OnBtnPressed -= DoBtnAction;
    }
}
