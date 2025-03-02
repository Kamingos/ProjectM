public interface ISideController
{
    public void TurnOn();
    public void SetSide();
    public void SetSide(bool spec);
    public string GetSide();
    public void ResetSide();
    public void StopUpdate();
}
