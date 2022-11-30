using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 10;
    [SerializeField] private float projectileLife = 10;

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
        if (other.gameObject.tag == "Environment")
        {
            Debug.Log("Collision");
            destroyProjectile();
        }
    }



}

