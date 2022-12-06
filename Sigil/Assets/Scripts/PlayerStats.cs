using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;
    [SerializeField] private int moveSpeed = 5;

    [Header("Buffs")]
    public float damageMultiplier = 1;
    public float castSpeedMultiplier = 1;
    public float spellEffectRadiusMultiplier = 1;




    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
