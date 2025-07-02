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
    
    public int currentStage;
    [SerializeField] private List<Stage> stageList;
    
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
        LoadStageData();
    }
    
    private void Start()
    {
        //LoadStageData();
    }
    
    private void LoadStageData()
    {
        int stageLevel = PlayerPrefs.GetInt("StageLevel");
        Button[] stageButtons = GameObject.Find("StageDeck").GetComponentsInChildren<Button>();
        for (int i = 0; i < stageList.Count ; i++)
        {
            if (stageList[i].level > stageLevel)
            {
                stageButtons[i].interactable = false;
            }
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
        if (currentStage < stageList.Count - 1) currentStage++;
        
        if (PlayerPrefs.GetInt("StageLevel") < currentStage)
        {
            PlayerPrefs.SetInt("StageLevel", currentStage);
        }
    }
}
