using System;

public interface IHealth
{
    public float MaxHP  { get; }
    public float Health { get; }
    public void Init(float _MaxHP, IHealthBar _healthBar, IDamageable _damage, IDeathController _deathController);

    public void ResetHP();

}
