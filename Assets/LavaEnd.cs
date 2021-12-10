using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaEnd : MonoBehaviour
{
    [SerializeField] Transform playerRespawn;
    [SerializeField] Transform batteryRespawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = playerRespawn.transform.position;
            SceneManager.LoadScene("TestScene");
        }

        if (other.gameObject.CompareTag("Key"))
        {
            other.transform.position = batteryRespawn.transform.position;
        }
    }
}
