using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public float baseMoveSpeed = 5;

    [Header("Buffs")]
    public float moveSpeedMultiplier = 1;
    public float damageMultiplier = 1;
    public float castSpeedMultiplier = 1;
    public float spellEffectRadiusMultiplier = 1;




    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        
    }

    public void TakeDamage(int damageToApply)
    {
        currentHealth -= damageToApply;
    }
}
