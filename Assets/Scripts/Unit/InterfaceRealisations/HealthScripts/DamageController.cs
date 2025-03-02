using DG.Tweening;
using UnityEngine;

public class DamageController : MonoBehaviour, IDamageable
{
    public void GetDamage(float health, float floatMaxHp)
    {
        if (health < floatMaxHp)
        {
            transform.DOScale(1.25f, 0.1f).From(1).SetEase(Ease.InOutExpo).SetLoops(2, LoopType.Yoyo);
        }
    }
}
