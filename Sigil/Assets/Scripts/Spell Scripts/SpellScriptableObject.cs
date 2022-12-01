using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Spells")]
public class SpellScriptableObject : ScriptableObject
{

    public float damageAmount = 1f;
    public float lifetime = 10f;
    public float speed = 10f;
    public float spellRadius = 0.5f;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
