using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    bool collided;
    [SerializeField] GameObject impactEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            var impact = Instantiate(impactEffect, collision.contacts[0].point, Quaternion.identity);

            Destroy(impact, 2);

            Destroy(gameObject);
            
        }
    }
}
