using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IHealth
{
    private IHealthBar healthBar;
    private float health;

    public event Action OnUnitDeath;
    public float MaxHP { get; private set; }
    public float Health
    {
        get => health; set
        {
            if (value < 0) { health = 0; OnUnitDeath?.Invoke(); }

            else if (value > MaxHP) health = MaxHP;

            else health = value;

            healthBar?.UpdateValue(health);
        }
    }

    public void Init(float _MaxHP, IHealthBar _healthBar)
    {
        MaxHP = _MaxHP;
        Health = MaxHP;

        healthBar = _healthBar;
    }
}
