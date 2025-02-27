using UnityEngine;

public class Unit : Entity, IUnit
{
    public IUnitController controller{ get; private set; }
    public IDamageable damageController { get; private set; }
    public IDeathController deathController { get; private set; }
    public IHealth healthController { get; private set; }
    public IBuildSystem buildController { get; private set; }
    public ISideDependence sideController { get; private set; }

    public UnitType type { get; private set; }

    public void Init(IUnitController _controller, IDamageable _damage, IDeathController _deathCtontroller,IHealth _unitHealth,
                     IBuildSystem _buildSystem, ISideDependence _sideController, UnitType _type)
    {
        controller = _controller;
        damageController = _damage;
        healthController = _unitHealth;
        buildController = _buildSystem;
        sideController = _sideController;
        deathController = _deathCtontroller;

        type = _type;

        buildController.BtnPressEvent += (_) => { if (_) { sideController.SetSide(_); } };
        healthController.OnUnitDeath += () => { deathController?.OnDied(); };

        buildController?.TurnOn();
        sideController?.TurnOn();
    }
    public void Copy(Unit unit)
    {
        controller = unit.controller;
        damageController = unit.damageController;
        deathController = unit.deathController;
        healthController = unit.healthController;
    }
    public override void GetDamage()
    {
        damageController?.GetDamage();
    }

    public override void OnDied()
    {
        deathController?.OnDied();
    }

}
