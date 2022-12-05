using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Spells")]
public class SpellScriptableObject : ScriptableObject
{
    public enum SpellType { Projectile, Arc };
    public SpellType spellType;


    [Header("Damage")]
    public int damageMinAmount = 1;
    public int damageMaxAmount = 2;
    public int passThroughAmount = 1;
    public float spellEffectRadius = 0;

    [Header("Speed")]
    public float cooldown = 0.5f;
    public float speed = 10f;
    public float spellColliderRadius = 0.5f;
    public float lifetime = 10f;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
