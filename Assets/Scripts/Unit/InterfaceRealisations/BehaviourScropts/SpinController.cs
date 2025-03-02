using System.Collections;
using UnityEngine;

public class SpinController : MonoBehaviour, IUnitController
{
    public void Init(float _attackRange, float _dammageValue, float _attackSpeed)
    {
        throw new System.NotImplementedException();
    }

    public void OnDied()
    {
        
    }

    public void TurnOff()
    {
        
    }

    public void TurnOn()
    {
        StartCoroutine(Rotating());
    }

    IEnumerator Rotating()
    {
        while (true)
        {
            transform.Rotate(0f, 5f, 0f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
