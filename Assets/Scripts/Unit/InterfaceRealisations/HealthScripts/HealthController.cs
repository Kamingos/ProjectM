using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IHealth
{
    private IHealthBar healthBar;
    private IDamageable damageController;
    private IDeathController deathController;

    public float health = -1;
    public float MaxHP { get; private set; }
    public float Health
    {
        get => health; set
        {

            if (value <= 0)
            {
                health = 0; deathController.OnDied();
            }

            else if (value > MaxHP) health = MaxHP;

            else health = value;

            healthBar?.UpdateValue(health);
            damageController.GetDamage(health, MaxHP);
        }
    }

    public void Init(float _MaxHP, IHealthBar _healthBar, IDamageable _damage, IDeathController _deathController)
    {
        healthBar = _healthBar;
        damageController = _damage;
        deathController = _deathController;

        MaxHP = _MaxHP;
        Health = MaxHP;
    }

    public void ResetHP()
    {
        health = MaxHP;
    }
}
