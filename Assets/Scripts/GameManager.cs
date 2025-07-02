using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Card firstCard;
    public Card secondCard;
    public GameObject failEndTxt;   //���� ������ �� UI
    public GameObject SuccEndTxt;   //���� ������ �� UI
    public Text timeTxt;
    public float time = 33.0f;
    AudioSource audioSource;
    public AudioClip clip;
    public AudioClip alarm;
    public int cardCount = 0;
    public Stage stage;
    public AudioClip complete;
    string overedTime1 = "30.00";
    string overedTime2 = "20.00";

    public AlarmAnim alarmAnim;
    private bool bAlarm = false;

    [SerializeField] private ResultPanel resultPanel;

    public bool isMatching = false;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        stage = StageManager.Instance.GetCurrentStage();

        // ���� ó��
        if (stage != null)
        {
            time = stage.time;
            cardCount = stage.maxCardCount;
        }
        else
        {
            time = 33.0f;
            cardCount = 10;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(cardCount != 0)
        { 
            time -= Time.deltaTime;
        }

        //2,4스테이지인 경우 20초까지 시간 고정
        if (stage.level == 1 || stage.level == 3)
        {
            if (time >= 20.0f)
            {
                timeTxt.text = overedTime2;
            }
            else
            {
                timeTxt.text = time.ToString("N2");
            }
        }
        //1,3스테이지 30초까지 시간 고정
        else if (time >= 30.0f)
        {
            timeTxt.text = overedTime1;
        }
        else
        {
            timeTxt.text = time.ToString("N2");
        }

        if (time <= 0.0f)
        {
            Time.timeScale = 0.0f;
            //failEndTxt.SetActive(true);
            resultPanel.Show(false, "실패..");
            StopAlarm();
        }

        if (time < 5f && !bAlarm)
        {
            bAlarm = true;
            PlayAlarm();
        }
    }

    private void PlayAlarm()
    {
        audioSource.clip = alarm;
        audioSource.loop = true;
        audioSource.Play();

        alarmAnim.AlarmStart();
    }

    private void StopAlarm()
    {
        audioSource.Stop();
        alarmAnim.AlarmStop();
    }

    public void Matched()
    {
        isMatching = true;

        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                //Time.timeScale = 0.0f;   
                SuccEndTxt.SetActive(true);
                StopAlarm();
                audioSource.PlayOneShot(complete);

                resultPanel.Show(true, "성공!");

                // Stage level increased when stage clear
                //StageManager.Instance.IncreaseStageLevel();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }
    public void ReduceTimeByBomb()
    {
        time -= 5.0f;
        if (time < 0f) time = 0f;
    }
}