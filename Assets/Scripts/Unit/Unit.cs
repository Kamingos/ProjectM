using UnityEngine;

public class Unit : Entity, IUnit
{
    public IUnitController controller{ get; private set; }
    public IDamageable damage { get; private set; }
    public IOnDied onDied { get; private set; }
    public IHealth health { get; private set; }
    public IBuildSystem buildController { get; private set; }
    public ISideDependence sideController { get; private set; }

    public UnitType type { get; private set; }

    public void Init(IUnitController _controller, IDamageable _damage, IOnDied _onDied,IHealth _unitHealth,
                     IBuildSystem _buildSystem, ISideDependence _sideController, UnitType _type)
    {
        controller = _controller;
        damage = _damage;
        onDied = _onDied;
        health = _unitHealth;
        buildController = _buildSystem;
        sideController = _sideController;
        type = _type;

        buildController.BtnPressEvent += (_) => { if (_) { sideController.SetSide(_); } };

        buildController?.TurnOn();
        sideController?.TurnOn();
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
