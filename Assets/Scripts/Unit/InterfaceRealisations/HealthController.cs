using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IHealth
{
    private IHealthBar healthBar;
    private IDamageable damageController;
    private IDeathController deathController;

    public float health;
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
        }
    }

    public void Init(float _MaxHP, IHealthBar _healthBar, IDamageable _damage, IDeathController _deathController)
    {
        MaxHP = _MaxHP;
        Health = MaxHP;

        healthBar = _healthBar;
        damageController = _damage;
        deathController = _deathController;
    }
}
