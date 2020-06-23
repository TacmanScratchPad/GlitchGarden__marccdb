using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 2f;
    [SerializeField] float damage = 100f;


    
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * projectileSpeed);
    }



    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        health.DealDamage(damage);
        Destroy(gameObject);
    }



  
}
