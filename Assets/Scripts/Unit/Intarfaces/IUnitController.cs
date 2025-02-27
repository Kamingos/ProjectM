using UnityEngine;

public interface IUnitController
{
    public void Init(float _attackRange, float _dammageValue, float _attackSpeed);
    public void OnDied();
}
