using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class StageManager : MonoBehaviour
{
    public static StageManager _instance;

    // 외부에서 혹시 생성이 되지 않았는데 접근한 경우를 위한 프로퍼티
    public static StageManager Instance
    {
        get
        {
            // 인스턴스가 아직 없다면 새로 생성
            if (_instance == null)
            {
                var go = new GameObject(nameof(StageManager));
                _instance = go.AddComponent<StageManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public List<Stage> Stage_List
    {
        get { return stageList; }
    }

    [SerializeField] private GameObject stageDeck;
    public int currentStage;
    private List<Stage> stageList;
    

    private void Awake()
    {
        // 정상 루트로 접근 한 경우
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
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
        if (stageDeck == null)
            return;

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
        // 예외처리 (메인신에서 바로 테스트하는 경우)
        if (stageList == null)
            return null;

        return stageList[currentStage];
    }

}
