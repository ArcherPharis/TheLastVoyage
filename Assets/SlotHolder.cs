using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHolder : MonoBehaviour
{
    [Tooltip("don't drag anything here")]
    [SerializeField] GameObject key;
    [SerializeField] string nameOfKey;
    [SerializeField] Transform socket;
    [SerializeField] GameObject connectEffect;
    [SerializeField] Transform effectSlot;
    [SerializeField] AudioSource objectForAudioToPlay;
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        objectForAudioToPlay.GetComponent<AudioSource>();
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
            objectForAudioToPlay.Play();
            key = GameObject.Find(nameOfKey);
            Destroy(key.GetComponent<Rigidbody>());
            key.transform.position = socket.transform.position;
            boxCollider.enabled = false;

            var impact = Instantiate(connectEffect, effectSlot.transform.position, Quaternion.identity);

            Destroy(impact, 2);
        }
    }
}
