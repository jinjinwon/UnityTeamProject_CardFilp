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

    // �ܺο��� Ȥ�� ������ ���� �ʾҴµ� ������ ��츦 ���� ������Ƽ
    public static StageManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ���ٸ� ���� ����
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
        // ���� ��Ʈ�� ���� �� ���
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
        // ����ó�� (���νſ��� �ٷ� �׽�Ʈ�ϴ� ���)
        if (stageList == null)
            return null;

        return stageList[currentStage];
    }
    
    public void IncreaseStageLevel()
    {
        
        PlayerPrefs.SetInt("StageLevel", currentStage + 1);
    }
}
