using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    [HideInInspector] public PlayerStats playerStats;

    public SpellScriptableObject spellToCast;

    [SerializeField] private SphereCollider spellCollider;
    private Rigidbody spellRigidbody;

    private int passThroughAmount;

    private void Awake()
    {
        spellCollider.GetComponent<SphereCollider>();
        spellCollider.isTrigger = true;
        spellCollider.radius = spellToCast.spellColliderRadius;

        spellRigidbody = GetComponent<Rigidbody>();
        spellRigidbody.isKinematic = true;

        passThroughAmount = spellToCast.passThroughAmount;

        Destroy(this.gameObject, spellToCast.lifetime);
    }

    private void Update()
    {
        if (spellToCast.speed > 0)
        {
            transform.Translate(Vector3.forward * spellToCast.speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Environment")
        {
            if (spellToCast.spellEffectRadius > 0)
            {
                AreaDamageEnemies(transform.position, spellToCast.spellEffectRadius * playerStats.spellEffectRadiusMultiplier);
            }
            DestroySpell();
        }
        if (other.gameObject.tag == "Enemy")
        {
            HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
            passThroughAmount -= 1;

            if (spellToCast.spellEffectRadius == 0)
            {
                //enemyHealth.TakeDamage(Random.Range(spellToCast.damageMinAmount, spellToCast.damageMaxAmount + 1));
                float damageTaken = Random.Range(spellToCast.damageMinAmount * playerStats.damageMultiplier, spellToCast.damageMaxAmount * playerStats.damageMultiplier);
                enemyHealth.TakeDamage(Mathf.RoundToInt(damageTaken));
            }
            else
            {
                AreaDamageEnemies(transform.position, spellToCast.spellEffectRadius * playerStats.spellEffectRadiusMultiplier);
            }

            if (passThroughAmount <= 0)
            {
                DestroySpell();
            }
        }
    }

    void AreaDamageEnemies(Vector3 location, float radius)
    {
        {
            Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
            foreach (Collider hit in objectsInRange)
            {
                if (hit.tag == "Enemy")
                {
                    HealthComponent enemyHealth = hit.GetComponent<HealthComponent>();
                    //enemyHealth.TakeDamage(Random.Range(spellToCast.damageMinAmount, spellToCast.damageMaxAmount + 1));

                    float damageTaken = Random.Range(spellToCast.damageMinAmount * playerStats.damageMultiplier, spellToCast.damageMaxAmount * playerStats.damageMultiplier);
                    enemyHealth.TakeDamage(Mathf.RoundToInt(damageTaken));

                    DestroySpell();
                }
            }
        }
    }

    private void DestroySpell()
    {
        Destroy(this.gameObject);
    }
}
