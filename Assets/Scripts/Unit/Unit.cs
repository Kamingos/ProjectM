using UnityEngine;

public class Unit : Entity, IUnit
{
    private IUnitController controller;
    private IDamageable damage;
    private IOnDied onDied;
    private IHealth health;
    private IBuildSystem buildSystem;

    private float speed;
    
    public void Init(IUnitController _controller, IDamageable _damage, IOnDied _onDied, IHealth _unitHealth, IBuildSystem _buildSystem)
    {
        controller = _controller;
        damage = _damage;
        onDied = _onDied;
        health = _unitHealth;
        buildSystem = _buildSystem;

        controller?.TurnOn();
    }
    public void Copy(Unit unit)
    {
        controller = unit.controller;
        damage = unit.damage;
        onDied = unit.onDied;
        health = unit.health;
    }
    public override void GetDamage()
    {
        damage?.GetDamage();
    }

    public override void OnDied()
    {
        onDied?.OnDied();
    }

}
