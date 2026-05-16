using System;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField] float startLife = 1f;
    [SerializeField] float damagePerHit = 0.3f;

    public UnityEvent<float, float> onLifeChanged;
    public UnityEvent<float> onLifeDepleted; //vida agotada
    HurtCollider hurtCollider;

    private float currentLife;

    [SerializeField] bool debugReceiveDamage;

    /// <summary>
    /// Sólo se llama desde el inspector, al cargar el script o al cambiar una variable en el editor
    /// </summary>
    private void OnValidate()
    {
        if (this.debugReceiveDamage)
        { 
            this.debugReceiveDamage = false;
            OnHitReceive();
        }
        
    }

    private void Awake()
    {
        this.hurtCollider = GetComponent<HurtCollider>(); 
        this.currentLife = startLife;

    }

    private void OnEnable()
    {
        this.hurtCollider.onHitReceive.AddListener(OnHitReceive);
    }

    private void OnDisable()
    {
        this.hurtCollider.onHitReceive.RemoveListener(OnHitReceive);
    }

    private void OnHitReceive()
    {
        this.currentLife -= damagePerHit;
        
        if (this.currentLife > 0)
        {
            onLifeChanged.Invoke(this.currentLife, this.startLife);
        }
        else
        {
            this.currentLife = 0f;
            onLifeDepleted.Invoke(this.startLife);
        }

    }

    internal void Restart()
    {
        this.currentLife = startLife;
        onLifeChanged.Invoke(this.currentLife, this.startLife);
    }
}
