using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5;
    [SerializeField] private float projectileLife = 10;
    [SerializeField] private float projectileDamage = 1;


    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
        projectileLife -= Time.deltaTime;

        if (projectileLife <= 0)
        {
            destroyProjectile();
        }
    }

    private void destroyProjectile()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            float damageTaken = projectileDamage;
            playerStats.TakeDamage(Mathf.RoundToInt(projectileDamage));
            destroyProjectile();
        }

        if (other.gameObject.tag == "Environment")
        {
            Debug.Log("Collision");
            destroyProjectile();
        }
    }



}

