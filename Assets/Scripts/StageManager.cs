using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    
    [SerializeField] private GameObject stageDeck;
    public int currentStage;
    private List<Stage> stageList;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        LoadStageData();
    }
    
    private void LoadStageData()
    {
        int.TryParse(PlayerPrefs.GetString("StageLevel"), out int stageLevel);
        var stages = stageDeck.GetComponentsInChildren<Button>();
        stageList = new List<Stage>();
        
        for (int i = 0; i < stages.Length ; i++)
        {
            var stage = stages[i].gameObject.GetComponent<Stage>();
            if (stage.level > stageLevel)
            {
                stages[i].interactable = false;
            }
            
            stageList.Add(stage);
        }
    }
    
    public Stage GetCurrentStage()
    {
        return stageList[currentStage];
    }

}
