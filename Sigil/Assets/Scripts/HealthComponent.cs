using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5f;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
