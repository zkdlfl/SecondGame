using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkin : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3f;
    [SerializeField] private float _damageThreshhold = 1f;
    private float _currentHelath;
    [SerializeField] private int pointsForDestruction = 10;

    public void Awake()
    {
        _currentHelath = _maxHealth;
    }
    public void DamangePumpkin(float damageAmount)
    {
        _currentHelath -= damageAmount;
        if (_currentHelath <= 0f)
        {
            Die();
        }

    }
    private void Die()
    {
        Points.instance.AddScore(pointsForDestruction);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactVelocity = collision.relativeVelocity.magnitude;
        if (impactVelocity > _damageThreshhold)
        {
            DamangePumpkin(impactVelocity);
        }
    }
}
