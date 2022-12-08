using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum Upgrade { healthBoost, speedMultiplier, damageMultiplier, castSpeedMultiplier, spellEffectRadiusMultiplier };
    public Upgrade upgrade;

    void Awake()
    {
        upgrade = (Upgrade)Random.Range(0, System.Enum.GetValues(typeof(Upgrade)).Length);
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IncreaseStats(other.GetComponent<PlayerStats>());
        }
    }

    public void IncreaseStats(PlayerStats playerStats)
    {
        if (upgrade == Upgrade.healthBoost)
        {
            playerStats.maxHealth += 5;
            playerStats.currentHealth += 5;
        }
        if (upgrade == Upgrade.speedMultiplier)
        {
            playerStats.moveSpeedMultiplier += 0.1f;
        }
        if (upgrade == Upgrade.damageMultiplier)
        {
            playerStats.damageMultiplier += 0.1f;
        }
        if (upgrade == Upgrade.castSpeedMultiplier)
        {
            playerStats.castSpeedMultiplier += 0.1f;
        }
        if (upgrade == Upgrade.spellEffectRadiusMultiplier)
        {
            playerStats.spellEffectRadiusMultiplier += 0.1f;
        }

        Destroy(this.gameObject);

    }


}
