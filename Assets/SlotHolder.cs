using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHolder : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] Transform socket;
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }


    private void Update()
    {


    }
    public bool KeyIsInSocket()
    {
        if (key)
        {
            return true;
        }
        return false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.transform.SetParent(transform, true);
            key = GameObject.Find("Key");
            Destroy(key.GetComponent<Rigidbody>());
            key.transform.position = socket.transform.position;
            boxCollider.enabled = false;
        }
    }
}
