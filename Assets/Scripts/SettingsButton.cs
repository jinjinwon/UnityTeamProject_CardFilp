using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using Unity.VisualScripting;

public class SettingsButton : MonoBehaviour
{
    public GameObject SettingsOpen;
    
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
    }




}
