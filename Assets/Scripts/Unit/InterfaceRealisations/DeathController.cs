using UnityEngine;

public class DeathController : MonoBehaviour, IDeathController
{
    public void OnDied()
    {
        Debug.Log(transform.name + " Умер");
        gameObject.SetActive(false);
    }
}
