using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    public SpellScriptableObject spellToCast;

    private SphereCollider spellCollider;
    private Rigidbody spellRigidbody;

    private void Start()
    {
        spellCollider.GetComponent<SphereCollider>();
        spellCollider.isTrigger = true;
        spellCollider.radius = spellToCast.spellRadius;

        spellRigidbody = GetComponent<Rigidbody>();
        spellRigidbody.isKinematic = true;

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
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(spellToCast.damageAmount);
            Destroy(this.gameObject);
        }
    }
}
