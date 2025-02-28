using UnityEngine;

public class Unit : Entity, IUnit
{
    public IUnitController controller{ get; private set; }
    public IHealth healthController { get; private set; }
    public IBuildSystem buildController { get; private set; }
    public UnitType type { get; private set; }

    public void Init(IUnitController _controller,IHealth _unitHealth, IBuildSystem _buildSystem,
                     UnitType _type)
    {
        controller = _controller;
        healthController = _unitHealth;
        buildController = _buildSystem;

        type = _type;
    }
    public void Copy(Unit unit)
    {
        controller = unit.controller;
        healthController = unit.healthController;
    }
}
