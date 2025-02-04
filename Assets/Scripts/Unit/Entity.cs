using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected GameObject gameModel;
    protected Animator animator;
    public abstract void GetDamage();
    public abstract void OnDied();
}
