using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIText : MonoBehaviour
{

    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
