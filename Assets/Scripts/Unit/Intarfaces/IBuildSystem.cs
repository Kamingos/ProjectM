using System;

public interface IBuildSystem 
{
    public event Action<bool> BtnPressEvent;

    public void TurnOn();
}
