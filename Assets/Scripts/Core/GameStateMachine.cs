using System;

public static class GameStateMachine
{
    public static event Action<GameMode> GameModeChanged;
    public static event Action OnRestartLevel;
    public static GameMode CurrentGameMode {  get; private set; }

    public static void SetNothingMode() => ChangeMode(GameMode.Nothing);
    public static void SetMenuMode() => ChangeMode(GameMode.Menu);
    public static void SetDefaultMode() => ChangeMode(GameMode.Default);
    public static void SetEditingMode() => ChangeMode(GameMode.Editing);
    public static void SetGameMode() => ChangeMode(GameMode.Game);
    public static void SetPauseMode() => ChangeMode(GameMode.Pause);
    private static void ChangeMode(GameMode gameMode)
    {
        if (CurrentGameMode == GameMode.Game && gameMode == GameMode.Default) OnRestartLevel.Invoke();

        // заглушки
        if (GameModeChanged == null) GameModeChanged += (_) => { };
        if (OnRestartLevel == null) OnRestartLevel += () => { };

        CurrentGameMode = gameMode;
        GameModeChanged.Invoke(CurrentGameMode);
    }
}
