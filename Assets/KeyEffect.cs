using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEffect : MonoBehaviour
{
    [SerializeField] GameObject connectEffect;
    [SerializeField] Transform slot;


    private void Start()
    {

       var item =  Instantiate(connectEffect, slot.transform.position, Quaternion.identity);
        item.transform.parent = transform;

    }


    private void Update()
    {
        
        
    }


}
