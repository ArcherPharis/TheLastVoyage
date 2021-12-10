using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] GameObject InGamePanel;
    [SerializeField] GameObject PausePanel;


    private void Awake()
    {
        PausePanel.SetActive(true);
        
    }

    private void Start()
    {
        StartCoroutine(LateStart(0.01f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PausePanel.SetActive(false);
    }



    public void SwitchPausePanel()
    {
        InGamePanel.SetActive(false);
        PausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void SwitchInGamePanel()
    {
        InGamePanel.SetActive(true);
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
