using UnityEngine;

[CreateAssetMenu(menuName = "ProjectM/UnitPreset")]

public class UnitPreset : ScriptableObject
{
    public GameObject? Model;
    public Animator? Animator;

    public float Speed;
    public int MaxHP;

    [field: SerializeField] public IUnitAction? BaseAction;
    public IUnitAction? UltimateAction;

    public IUnitController? Controller;
    public IDamageable? Damage;
    public IOnDied? OnDied;
    public IHealth? Health;

}
