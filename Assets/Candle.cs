using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    ParticleSystem particleSystem;
    GroundItem groundItem;


    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        groundItem = GetComponent<GroundItem>();
        particleSystem.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            particleSystem.Play();
            groundItem.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
