using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFind : MonoBehaviour
{
    //[SerializeField] GameObject gameObjectToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("candle is here!");
            Destroy(gameObject);
        }
    }
}
