using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject stageDeck;
    private void Start()
    {
        LoadStageData();
    }
    
    private void LoadStageData()
    {
        int.TryParse(PlayerPrefs.GetString("CurrentStage"), out int currentStage);
        Button[] stages = stageDeck.GetComponentsInChildren<Button>();
        
        for (int i = 0; i < stages.Length; i++)
        {
            if (stages[i].GetComponent<Stage>().level > currentStage)
            {
                stages[i].interactable = false;
            }
        }
    }
}
