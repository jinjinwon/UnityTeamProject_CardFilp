using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using Unity.VisualScripting;

public class SettingsButton : MonoBehaviour
{
    public GameObject SettingsOpen;
    public GameObject BackButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSetting()
    {
        SettingsOpen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ClickBack()
    {
        SettingsOpen.SetActive(false);
        Time.timeScale = 1f;
        
    }



}
