using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public GameObject damageText;
    public GameObject damageTextPopupPoint;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damageToApply)
    {
        currentHealth -= damageToApply;

        Debug.Log(damageToApply);

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        if (damageText)
        {
            DamagePopup popup = Instantiate(damageText, damageTextPopupPoint.transform.position, Quaternion.identity).GetComponent<DamagePopup>();
            popup.SetDamageText(damageToApply);
        }
    }

    void ShowFloatingText()
    {
        Instantiate(damageText, transform.position, Quaternion.identity, transform);
    }
}
