using UnityEngine;
using UnityEngine.Events;

public class HurtCollider : MonoBehaviour
{
    public UnityEvent onHitReceive;


    internal void NotifyHit(HitCollider hitCollider)
    {
        onHitReceive.Invoke();
    }


}
